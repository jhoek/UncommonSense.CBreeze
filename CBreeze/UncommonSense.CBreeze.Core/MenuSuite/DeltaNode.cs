using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
    public class DeltaNode : MenuSuiteNode
    {
        public DeltaNode(Guid id)
            : base(id)
        {
            Properties = new MenuSuiteDeltaNodeProperties(this);
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.Delta;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public MenuSuiteDeltaNodeProperties Properties
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

        public override string GetName()
        {
            return null;
        }
    }
}
