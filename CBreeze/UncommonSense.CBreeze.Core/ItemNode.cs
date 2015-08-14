using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ItemNode : MenuSuiteNode
    {
        private MenuSuiteItemNodeProperties properties = new MenuSuiteItemNodeProperties();

        internal ItemNode(Guid id) : base(id)
        {
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.ItemNode;
            }
        }

        public MenuSuiteItemNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
