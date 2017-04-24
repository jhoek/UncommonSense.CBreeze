using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewCBreezeObject : PSCmdlet
    {
        protected const string AddWithID = "AddWithID";
        protected const string AddWithoutID = "AddWithoutID";
        protected const string NewWithID = "NewWithID";
        protected const string NewWithoutID = "NewWithoutID";

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter()]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = NewWithID)]
        [ValidateRange(0, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AddWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AddWithoutID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = NewWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = NewWithoutID)]
        [ValidateLength(1, 30)]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 3, ParameterSetName = AddWithID)]
        [Parameter(Position = 2, ParameterSetName = AddWithoutID)]
        [Parameter(Position = 3, ParameterSetName = NewWithID)]
        [Parameter(Position = 2, ParameterSetName = NewWithoutID)]
        public ScriptBlock SubObjects
        {
            get; set;
        }

        [Parameter()]
        public string VersionList
        {
            get;
            set;
        }

        protected void SetObjectProperties(Core.Object @object)
        {
            @object.ObjectProperties.DateTime = DateTime;
            @object.ObjectProperties.Modified = Modified;
            @object.ObjectProperties.VersionList = VersionList;
        }
    }
}