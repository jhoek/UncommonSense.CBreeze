using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTable", DefaultParameterSetName = WithoutID)]
    public class AddCBreezeTable : NewCBreezeTable
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application { get; set; }

        [Parameter()]
        public SwitchParameter PassThru { get; set; } = true;

        protected override void ProcessRecord()
        {
            Application.Tables.Add(CreateTable()).DoIf(PassThru, t => WriteObject(t));
        }
    }
}