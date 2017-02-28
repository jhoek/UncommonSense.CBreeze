using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public abstract class PageControl : KeyedItem<int>, IHasName, IHasProperties, INode
    {
        internal PageControl(int id, int? indentationLevel)
        {
            ID = id;
            IndentationLevel = indentationLevel;
        }

        public virtual PageControls Container
        {
            get;
            internal set;
        }

        public abstract PageControlType Type
        {
            get;
        }

        public int? IndentationLevel
        {
            get;
            protected set;
        }

        public abstract string GetName();

        public abstract Properties AllProperties
        {
            get;
        }

        public int Index
        {
            get
            {
                return Container.IndexOf(this);
            }
        }

        public IEnumerable<PageControl> DescendantPageControls
        {
            get
            {
                return Container.Skip(Index + 1).TakeWhile(c => c.IndentationLevel > (IndentationLevel ?? 0));
            }
        }

        public IEnumerable<PageControl> ChildPageControls
        {
            get
            {
                return DescendantPageControls.Where(c => c.IndentationLevel == (IndentationLevel ?? 0) + 1);
            }
        }

        public PageControl ParentPageControl
        {
            get
            {
                return Container.Where(c => c.IndentationLevel == (IndentationLevel ?? 0) - 1).Where(c => c.Index < Index).Last();
            }
        }

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }

        public T AddChildPageControl<T>(T child, Position position) where T : PageControl
        {
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
    }
}
