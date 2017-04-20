using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTable")]
    public class AddCBreezeTable : NewCBreezeTable
    {
        public AddCBreezeTable()
        {
            PassThru = true;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var table = CreateTable();
            Application.Tables.Add(table);

            if (PassThru)
            {
                WriteObject(table);
            }
        }
    }
}