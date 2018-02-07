using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public abstract class ReportElement : KeyedItem<int>, IHasName, IHasProperties, INode
	{
		public ReportElement(int id, int? indentationLevel)
		{
			ID = id;
			IndentationLevel = indentationLevel;
		}

		public abstract ReportElementType Type
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

        public IEnumerable<ReportElement> DescendantElements
        {
            get
            {
                return Container.Skip(Index + 1).TakeWhile(e => e.IndentationLevel.GetValueOrDefault(0) > IndentationLevel.GetValueOrDefault(0));
            }
        }

        public T AddChildNode<T>(T child, Position position) where T : ReportElement
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantElements = DescendantElements;
                    var lastIndex = descendantElements.Any() ? descendantElements.Last().Index : Index;
                    Container.Insert(lastIndex + 1, child);
                    break;
            }

            return child;
        }

        public ReportElements Container { get; internal set; }

		public int? IndentationLevel
		{
			get;
			protected set;
		}

		public string Name
		{
			get;
			set;
		}

		public abstract Properties AllProperties
		{
			get;
		}

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes 
        {
            get;
        }

        public string GetName()
		{
			return Name;
		}
	}
}
