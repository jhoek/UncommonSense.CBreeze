using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePermission")]
    [OutputType(typeof(Permission))]
    [Alias("Permission")]
    public class NewCBreezePermission : Cmdlet
    {
        [Parameter()]
        public SwitchParameter Delete
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Insert
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Modify
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter Read
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateRange(1, int.MaxValue)]
        public int TableID
        {
            get;
            set;
        }

        protected override void EndProcessing()
        {
            WriteObject(new Permission(TableID, Read, Insert, Modify, Delete));
        }
    }
}