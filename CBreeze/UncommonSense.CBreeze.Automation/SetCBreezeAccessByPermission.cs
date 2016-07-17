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
        }

        protected AccessByPermission GetAccessByPermission()
        {
            AccessByPermission result = null;

            TypeSwitch.Do(
                InputObject.BaseObject,
                TypeSwitch.Case<BigIntegerTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<BinaryTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<BlobTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<BooleanTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<CodeTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<DateFormulaTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<DateTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<DateTimeTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<DecimalTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<DurationTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<FieldPageControlProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<GuidTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<IntegerTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<MenuSuiteItemNodeProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<OptionTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<PageActionProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<PartPageControlProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<RecordIDTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<TableFilterTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<TextTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Case<TimeTableFieldProperties>(i => result = i.AccessByPermission),
                TypeSwitch.Default(() => InvalidInputObject())
            );

            return result;
        }

        protected void InvalidInputObject()
        {
            throw new ArgumentOutOfRangeException("Don't know how to set the AccessByPermission property for this input object.");
        }
    }
#endif
}
