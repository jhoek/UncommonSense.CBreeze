using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageActionItems")]
    public class GetCBreezePageActionItems : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter(Mandatory=true)]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(Page.GetActionItems(Range));
        }
    }
}
