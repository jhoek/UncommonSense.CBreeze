using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class GroupPageControl : PageControl
    {
        private GroupPageControlProperties properties = new GroupPageControlProperties();

        internal GroupPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Group;
            }
        }

        public GroupPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
