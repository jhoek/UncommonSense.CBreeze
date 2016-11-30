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
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "IDPresentAndAutoObjectProperties")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "IDPresentAndManualObjectProperties")]
        [ValidateRange(0, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "IDPresentAndAutoObjectProperties")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "IDPresentAndManualObjectProperties")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "IDNotPresentAndAutoObjectProperties")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "IDNotPresentAndManualObjectProperties")]
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

        [Parameter(ParameterSetName = "IDPresentAndAutoObjectProperties")]
        [Parameter(ParameterSetName = "IDNotPresentAndAutoObjectProperties")]
        public SwitchParameter AutoObjectProperties
        {
            get; set;
        }

        [Parameter(ParameterSetName = "IDPresentAndManualObjectProperties")]
        [Parameter(ParameterSetName = "IDNotPresentAndManualObjectProperties")]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "IDPresentAndManualObjectProperties")]
        [Parameter(ParameterSetName = "IDNotPresentAndManualObjectProperties")]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "IDPresentAndManualObjectProperties")]
        [Parameter(ParameterSetName = "IDNotPresentAndManualObjectProperties")]
        public string VersionList
        {
            get;
            set;
        }

        [Parameter()]
        public ScriptBlock SubObjects
        {
            get; set;
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
