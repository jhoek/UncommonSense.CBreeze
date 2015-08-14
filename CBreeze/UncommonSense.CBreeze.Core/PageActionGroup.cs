using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class PageActionGroup : PageActionBase
    {
        private PageActionGroupProperties properties = new PageActionGroupProperties();

        internal PageActionGroup(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public override PageActionBaseType Type
        {
            get
            {
                return PageActionBaseType.PageActionGroup;
            }
        }

        public PageActionGroupProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
