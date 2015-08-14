using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class PageActionSeparator : PageActionBase
    {
        private PageActionSeparatorProperties properties = new PageActionSeparatorProperties();

        internal PageActionSeparator(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageActionBaseType Type
        {
            get
            {
                return PageActionBaseType.PageActionSeparator;
            }
        }

        public PageActionSeparatorProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
