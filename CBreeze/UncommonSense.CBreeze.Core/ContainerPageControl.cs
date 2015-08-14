using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ContainerPageControl : PageControl
    {
        private ContainerPageControlProperties properties = new ContainerPageControlProperties();

        internal ContainerPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageControlType Type
        {
            get
            {
                return PageControlType.Container;
            }
        }

        public ContainerPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
