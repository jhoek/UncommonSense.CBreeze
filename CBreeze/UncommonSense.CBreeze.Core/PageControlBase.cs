using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public abstract class PageControlBase : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        internal PageControlBase(int id, int? indentationLevel)
        {
            ID = id;
            IndentationLevel = indentationLevel;
        }

        public abstract Properties AllProperties
        {
            get;
        }

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }

        public IEnumerable<PageControlBase> ChildPageControls
        {
            get
            {
                return DescendantPageControls.Where(c => c.IndentationLevel == (IndentationLevel ?? 0) + 1);
            }
        }

        public virtual PageControls Container
        {
            get;
            internal set;
        }

        public IEnumerable<PageControlBase> DescendantPageControls
        {
            get
            {
                return Container.Skip(Index + 1).TakeWhile(c => c.IndentationLevel > (IndentationLevel ?? 0));
            }
        }

        public int? IndentationLevel
        {
            get;
            protected set;
        }

        public int Index
        {
            get
            {
                return Container.IndexOf(this);
            }
        }

        public INode ParentNode => Container;

        public PageControlBase ParentPageControl
        {
            get
            {
                return Container.Where(c => c.IndentationLevel == (IndentationLevel ?? 0) - 1).Where(c => c.Index < Index).Last();
            }
        }

        public abstract PageControlType Type
        {
            get;
        }

        public T AddChildPageControl<T>(T child, Position position) where T : PageControlBase
        {
            child.IndentationLevel = child.IndentationLevel ?? IndentationLevel.GetValueOrDefault(0) + 1;

            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;

                case Position.LastWithinContainer:
                    var descendantPageControls = DescendantPageControls;
                    var lastIndex = descendantPageControls.Any() ? descendantPageControls.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }

        public abstract string GetName();
    }
}