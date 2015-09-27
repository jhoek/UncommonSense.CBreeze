using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDateTableField")]
    public class AddCBreezeDateTableField : AddCBreezeTableField
    {
        [Parameter()]
        public string AltSearchField
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var table in Table)
            {
                var field = table.Fields.Add(new DateTableField(GetNo(), Name));

                field.Properties.AltSearchField = AltSearchField;

                if (AutoCaption)
                    field.AutoCaption();

                if (PassThru)
                    WriteObject(field);
            }
        }
    }
}
