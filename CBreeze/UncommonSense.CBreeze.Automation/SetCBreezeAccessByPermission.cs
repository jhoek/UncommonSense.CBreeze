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

    [Cmdlet(VerbsCommon.Set, "CBreezeAccessByPermission")]
    [Alias("AccessByPermission")]
    public class SetCBreezeAccessByPermission : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 0)]
        public AccessByPermissionObjectType ObjectType
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
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
            var accessByPermission = GetAccessByPermission();

            accessByPermission.ObjectType = ObjectType;
            accessByPermission.ObjectID = ObjectID;

            accessByPermission.Read = Read;
            accessByPermission.Insert = Insert;
            accessByPermission.Modify = Modify;
            accessByPermission.Delete = Delete;
            accessByPermission.Execute = Execute;

            WriteObject(InputObject);
        }

        protected AccessByPermission GetAccessByPermission()
        {
            switch (InputObject.BaseObject)
            {
                case TableField f:
                    return (f.AllProperties["AccessByPermission"] as AccessByPermissionProperty).Value;

                case FieldPageControl c:
                    return c.Properties.AccessByPermission;

                case PageAction a:
                    return a.Properties.AccessByPermission;

                case PartPageControl c:
                    return c.Properties.AccessByPermission;

                case ItemNode n:
                    return n.Properties.AccessByPermission;

                case Properties p:
                    return (p["AccessByPermission"] as AccessByPermissionProperty).Value;

                default:
                    throw new ArgumentOutOfRangeException("Don't know how to set the AccessByPermission property for this input object.");
            }
        }
    }

#endif
}