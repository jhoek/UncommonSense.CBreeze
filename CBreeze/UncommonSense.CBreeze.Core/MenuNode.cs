using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class MenuNode : MenuSuiteNode
    {
        private MenuSuiteMenuNodeProperties properties = new MenuSuiteMenuNodeProperties();

        internal MenuNode(Guid id) : base(id)
        {
        }

        public override MenuSuiteNodeType Type
        {
            get
            {
                return MenuSuiteNodeType.MenuNode;
            }
        }

        public MenuSuiteMenuNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
