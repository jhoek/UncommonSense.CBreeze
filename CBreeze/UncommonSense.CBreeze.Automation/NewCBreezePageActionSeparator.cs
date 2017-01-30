using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionSeparator")]
    [OutputType(typeof(PageActionSeparator))]
    public class NewCBreezePageActionSeparator : NewCBreezePageActionBase
    {
        [Parameter()]
        public string Caption
        {
            get; set;
        }

        [Parameter()]
        public bool? IsHeader
        {
            get; set;
        }

        protected PageActionSeparator CreatePageActionSeparator()
        {
            var pageActionSeparator = new PageActionSeparator(GetID(), GetIndentation());

            pageActionSeparator.Properties.CaptionML.Set("ENU", Caption);
            pageActionSeparator.Properties.IsHeader = IsHeader;

            return pageActionSeparator;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreatePageActionSeparator());
        }
    }
}
