﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Get, "CBreezePageControlGroup")]
    [OutputType(typeof(PageControlGroup))]
    public class GetCBreezePageControlGroup : PSCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "ByGroupCaption")]
        public string GroupCaption
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ByGroupType")]
        public PageControlGroupType GroupType
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
            var contentArea = Page.GetPageControlContainer(PageControlContainerType.ContentArea);

            switch (ParameterSetName)
            {
                case "ByGroupType":
                    WriteObject(contentArea.GetGroupByType(GroupType, Position ?? Core.Property.Enumeration.Position.FirstWithinContainer));
                    break;

                case "ByGroupCaption":
                    WriteObject(contentArea.GetGroupByCaption(GroupCaption, Position ?? Core.Property.Enumeration.Position.LastWithinContainer));
                    break;
            }
        }
    }
}