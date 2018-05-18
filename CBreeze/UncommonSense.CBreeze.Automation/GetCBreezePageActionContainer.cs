using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Action;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageActionContainer")]
    [OutputType(typeof(PageActionContainer))]
    public class GetCBreezePageActionContainer : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public PageActionContainerType Type
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(Page.GetPageActionContainer(Type));
        }
    }
}