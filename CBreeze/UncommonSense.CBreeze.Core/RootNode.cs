using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class RootNode : MenuSuiteNode
    {
        private MenuSuiteRootNodeProperties properties = new MenuSuiteRootNodeProperties();

        internal RootNode(Guid id) : base(id)
        {
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.RootNode;
            }
        }

        public MenuSuiteRootNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
