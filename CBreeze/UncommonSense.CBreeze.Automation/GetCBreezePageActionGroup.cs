using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageActionGroup")]
    [OutputType(typeof(PageActionGroup))]
    public class GetCBreezePageActionGroup : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Caption
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public ActionContainerType ContainerType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter()]
        public Position? Position
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var container = Page.GetPageActionContainer(ContainerType);
            WriteObject(container.GetGroupByCaption(Page, Caption, Position ?? Core.Position.LastWithinContainer));
        }
    }
}