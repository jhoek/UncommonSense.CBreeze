using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Report
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

        public IEnumerable<ReportElement> Descendants => Container.Skip(Index + 1).TakeWhile(e => e.IndentationLevel.GetValueOrDefault(0) > IndentationLevel.GetValueOrDefault(0));
        public IEnumerable<ReportElement> Children => Descendants.Where(e => e.IndentationLevel == this.IndentationLevel.GetValueOrDefault(0) + 1);

        public T AddChildNode<T>(T child, Position position) where T : ReportElement
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    Container.Insert(Index + 1, child);
                    break;
                case Position.LastWithinContainer:
                    var descendantElements = Descendants;
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
