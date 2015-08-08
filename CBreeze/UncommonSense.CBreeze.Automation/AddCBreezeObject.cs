using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class AddCBreezeObject : AddCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateLength(1, 30)]
        public string Name
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

        [Parameter()]
        public string VersionList
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
    }
}
