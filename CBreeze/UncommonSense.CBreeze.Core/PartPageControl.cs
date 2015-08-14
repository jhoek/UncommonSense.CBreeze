using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class PartPageControl : PageControl
    {
        private PartPageControlProperties properties = new PartPageControlProperties();

        internal PartPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Part;
            }
        }

        public PartPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
