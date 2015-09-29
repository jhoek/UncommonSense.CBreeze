using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Set, "CBreezePermission")]
    public class SetCBreezePermission : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public IHasProperties[] InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int TableID
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Read
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
        public SwitchParameter Delete
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var inputObject in InputObject)
            {
                GetPermissions(inputObject).Set(TableID, Read.IsPresent, Insert.IsPresent, Modify.IsPresent, Delete.IsPresent);
            }
        }

        protected Permissions GetPermissions(IHasProperties inputObject)
        {
            return (inputObject.AllProperties["Permissions"] as PermissionsProperty).Value;
        }
    }
}
