using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Property.Enumeration;

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
        public PageActionContainerType ContainerType
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
            WriteObject(container.GetGroupByCaption(Page, Caption, Position ?? Core.Property.Enumeration.Position.LastWithinContainer));
        }
    }
}