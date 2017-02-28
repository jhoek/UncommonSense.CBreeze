using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class MenuSuite : Object
    {
        public MenuSuite(int id, string name)
            : base(id, name)
        {
            Properties = new MenuSuiteProperties(this);
            Nodes = new MenuSuiteNodes(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.MenuSuite;
            }
        }

        public MenuSuites Container { get; internal set; }

        public MenuSuiteProperties Properties
        {
            get;
            protected set;
        }

        public MenuSuiteNodes Nodes
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Nodes;
            }
        }
    }
}
