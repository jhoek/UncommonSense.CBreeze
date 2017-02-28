using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class ReportLabel : KeyedItem<int>, IHasName, INode
	{
		public ReportLabel(int id, string name)
		{
			ID = id;
			Name = name;
			Properties = new ReportLabelProperties(this);
		}

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public ReportLabels Container { get; internal set; }

        public string Name
		{
			get;
			protected set;
		}

        public INode ParentNode => Container;

        public ReportLabelProperties Properties
		{
			get;
			protected set;
		}

		public string GetName()
		{
			return Name;
		}
	}
}
