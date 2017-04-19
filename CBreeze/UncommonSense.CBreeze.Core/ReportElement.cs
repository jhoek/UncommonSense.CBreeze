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
