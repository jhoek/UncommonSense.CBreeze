using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class FieldPageControl : PageControl
    {
        private FieldPageControlProperties properties = new FieldPageControlProperties();

        internal FieldPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Field;
            }
        }

        public FieldPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
