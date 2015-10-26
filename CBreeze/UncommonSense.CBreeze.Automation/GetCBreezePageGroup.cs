using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageGroup")]
    public class GetCBreezePageGroup : PSCmdlet
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

        [Parameter(Mandatory = true, ParameterSetName = "ByGroupType")]
        public GroupType GroupType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ByGroupCaption")]
        public string GroupCaption
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
            var contentArea = Page.GetPageControlContainer(Range, ContainerType.ContentArea);

            switch (ParameterSetName)
            {
                case "ByGroupType":
                    WriteObject(contentArea.GetGroupByType(GroupType, Range, Position ?? UncommonSense.CBreeze.Utils.Position.FirstWithinContainer));
                    break;
                case "ByGroupCaption":
                    WriteObject(contentArea.GetGroupByCaption(GroupCaption, Range, Position ?? UncommonSense.CBreeze.Utils.Position.LastWithinContainer));
                    break;
            }
        }
    }
}
