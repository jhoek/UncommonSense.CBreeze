using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBinaryTableField")]
    public class AddCBreezeBinaryTableField : AddCBreezeTableField
    {
        public AddCBreezeBinaryTableField()
        {
            DataLength = 4;
        }

        [Parameter()]
        [ValidateRange(1, 250)]
        public int DataLength
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var field = Table.Fields.Add(new BinaryTableField(GetTableFieldNo(), Name, DataLength));

            field.Properties.Description = Description;

            if (AutoCaption)
                field.AutoCaption();

            if (PassThru)
                WriteObject(field);
        }
    }
}
