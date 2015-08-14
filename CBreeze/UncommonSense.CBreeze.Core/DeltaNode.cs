using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DeltaNode : MenuSuiteNode
    {
        private MenuSuiteDeltaNodeProperties properties = new MenuSuiteDeltaNodeProperties();

        internal DeltaNode(Guid id) : base(id)
        {
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.DeltaNode;
            }
        }

        public MenuSuiteDeltaNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
