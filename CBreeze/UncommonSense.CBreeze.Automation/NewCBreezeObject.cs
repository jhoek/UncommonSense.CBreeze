using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewCBreezeObject : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Range")]
        public PSObject ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "AutoObjectProperties")]
        public SwitchParameter AutoObjectProperties
        {
            get; set;
        }

        [Parameter(ParameterSetName = "ManualObjectProperties")]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "ManualObjectProperties")]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "ManualObjectProperties")]
        public string VersionList
        {
            get;
            set;
        }

        protected void SetObjectProperties(Core.Object @object)
        {
            if (AutoObjectProperties.IsPresent)
            {
                @object.ObjectProperties.DateTime = System.DateTime.Now;
                @object.ObjectProperties.Modified = true;
            }
            else
            {
                @object.ObjectProperties.DateTime = DateTime;
                @object.ObjectProperties.Modified = Modified;
                @object.ObjectProperties.VersionList = VersionList;
            }
        }
    }
}
