using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageActionGroup")]
    public class GetCBreezePageActionGroup : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public IEnumerable<int> Range
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

        [Parameter(Mandatory=true)]
        public string Caption
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
            var container = Page.GetPageActionContainer(Range, ContainerType);
            WriteObject(container.GetGroupByCaption(Page, Caption, Range, Position ?? Core.Position.LastWithinContainer));
        }
    }
}
