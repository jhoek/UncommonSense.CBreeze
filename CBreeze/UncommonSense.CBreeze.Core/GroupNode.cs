using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class GroupNode : MenuSuiteNode
    {
        private MenuSuiteGroupNodeProperties properties = new MenuSuiteGroupNodeProperties();

        internal GroupNode(Guid id) : base(id)
        {
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.GroupNode;
            }
        }

        public MenuSuiteGroupNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
