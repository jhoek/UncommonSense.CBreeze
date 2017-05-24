using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class NewCBreezeObject<T> : NewNamedItemCmdlet<T, int, Application>
    {
        protected void SetObjectProperties(Core.Object @object)
        {
            @object.ObjectProperties.DateTime = DateTime;
            @object.ObjectProperties.Modified = Modified;
            @object.ObjectProperties.VersionList = VersionList;
        }

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

        [Parameter()]
        public SwitchParameter Modified
        {
            get;
            set;
        }

        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
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
    }
}