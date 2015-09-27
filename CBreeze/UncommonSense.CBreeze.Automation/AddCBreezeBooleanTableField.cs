using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBooleanTableField")]
    public class AddCBreezeBooleanTableField : AddCBreezeTableField
    {
        [Parameter()]
        public string AltSearchField
        {
            get;
            set;
        }

        [Parameter()]
        public bool BlankZero
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var table in Table)
            {
                var field = table.Fields.Add(new BooleanTableField(GetNo(), Name));

                field.Properties.AltSearchField = AltSearchField;
                field.Properties.BlankZero = BlankZero;

                if (AutoCaption)
                    field.AutoCaption();

                if (PassThru)
                    WriteObject(field);
            }
        }
    }
}
