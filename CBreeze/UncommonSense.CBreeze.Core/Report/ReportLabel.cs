using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Report
{
    public class ReportLabel : KeyedItem<int>, IHasName, INode, IHasProperties
    {
        public ReportLabel(string name) : this(0, name)
        {
        }

        public ReportLabel(int id, string name)
        {
            ID = id;
            Name = name;
            Properties = new ReportLabelProperties(this);
        }

        public Properties AllProperties => Properties;

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

        public string GetName() => Name;
    }
}