using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
#if NAV2015
    [Cmdlet(VerbsCommon.New, "CBreezeAccessByPermission")]
    [OutputType(typeof(AccessByPermission))]
    [Alias("AccessByPermission")]
    public class NewCBreezeAccessByPermission : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public AccessByPermissionObjectType ObjectType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        public int ObjectID
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

        [Parameter()]
        public SwitchParameter Execute
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var accessByPermission = new AccessByPermission
            {
                ObjectType = ObjectType,
                ObjectID = ObjectID,
                Read = Read,
                Insert = Insert,
                Modify = Modify,
                Delete = Delete,
                Execute = Execute
            };

            WriteObject(accessByPermission);
        }
    }

#endif
}