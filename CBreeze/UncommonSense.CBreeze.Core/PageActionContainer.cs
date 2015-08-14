using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class PageActionContainer : PageActionBase
    {
        private PageActionContainerProperties properties = new PageActionContainerProperties();

        internal PageActionContainer(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageActionBaseType Type
        {
            get
            {
                return PageActionBaseType.PageActionContainer;
            }
        }

        public PageActionContainerProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
