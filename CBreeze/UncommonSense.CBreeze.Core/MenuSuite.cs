using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class MenuSuite : Object
    {
        public MenuSuite(string name) : this(0, name)
        {
        }

        public MenuSuite(int id, string name)
            : base(id, name)
        {
            Properties = new MenuSuiteProperties(this);
            Nodes = new MenuSuiteNodes(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public Application Application => Container?.Application;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Nodes;
            }
        }

        public MenuSuites Container { get; internal set; }

        public MenuSuiteNodes Nodes
        {
            get;
            protected set;
        }

        public override INode ParentNode => Container;

        public MenuSuiteProperties Properties
        {
            get;
            protected set;
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.MenuSuite;
            }
        }
    }
}