using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTableKey")]
    public class AddCBreezeTableKey : NewCBreezeTableKey
    {
        [Parameter(Mandatory = true)]
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
            var tableKey = Table.Keys.Add(CreateKey());

            if (PassThru)
                WriteObject(tableKey);
        }
    }
}
