using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableFieldGroup")]
    public class AddCBreezeTableFieldGroup : NewCBreezeTableFieldGroup
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Table Table
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var tableFieldGroup = Table.FieldGroups.Add(CreateTableFieldGroup());

            if (PassThru)
                WriteObject(tableFieldGroup);
        }
    }
}
