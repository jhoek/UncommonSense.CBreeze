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
    public class NewCBreezePageActionSeparator : NewCBreezePageActionBase
    {
        [Parameter()]
        public string Caption
        {
            get; set;
        }

        public bool? IsHeader
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var pageActionSeparator = new PageActionSeparator(ID, GetIndentation());

            pageActionSeparator.Properties.CaptionML.Set("ENU", Caption);
            pageActionSeparator.Properties.IsHeader = IsHeader;

            WriteObject(pageActionSeparator);
        }
    }
}
