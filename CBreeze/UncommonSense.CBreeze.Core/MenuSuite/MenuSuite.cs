using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
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