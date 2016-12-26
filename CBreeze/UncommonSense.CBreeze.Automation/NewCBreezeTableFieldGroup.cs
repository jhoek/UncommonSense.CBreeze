using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeTableFieldGroup")]
    public class NewCBreezeTableFieldGroup : Cmdlet
    {
        public NewCBreezeTableFieldGroup()
        {
            ID = 1;
            Name = "DropDown";
        }

        [Parameter(Position = 0)]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Position = 1)]
        [ValidateNotNullOrEmpty()]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2)]
        public string[] FieldNames
        {
            get;
            set;
        }

        [Parameter()]
        public string Caption
        {
            get;
            set;
        }

        protected TableFieldGroup CreateTableFieldGroup()
        {
            var tableFieldGroup = new TableFieldGroup(ID, Name);
            tableFieldGroup.Properties.CaptionML.Set("ENU", Caption);
            tableFieldGroup.Fields.AddRange(FieldNames);

            return tableFieldGroup;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateTableFieldGroup());
        }
    }
}
