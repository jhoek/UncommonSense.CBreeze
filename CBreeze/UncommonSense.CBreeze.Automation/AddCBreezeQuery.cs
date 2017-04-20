using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeQuery")]
    public class AddCBreezeQuery : NewCBreezeQuery
    {
        public AddCBreezeQuery()
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
            var query = CreateQuery();
            Application.Queries.Add(query);

            if (PassThru)
            {
                WriteObject(query);
            }
        }
    }
}