using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
    public class RootNode : MenuSuiteNode
    {
        public RootNode(Guid id)
            : base(id)
        {
            Properties = new MenuSuiteRootNodeProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.Root;
            }
        }

        public MenuSuiteRootNodeProperties Properties
        {
            get;
            protected set;
        }

        public override string GetName()
        {
            return null;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
