using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageControlContainer")]
    [OutputType(typeof(ContainerPageControl))]
    public class GetCBreezePageControlContainer : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public ContainerType Type
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(Page.GetPageControlContainer(Type));
        }
    }
}