using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeLine")]
    public class AddCBreezeCodeLine : PSCmdlet
    {
        [Parameter(Mandatory=true,ParameterSetName="Trigger",ValueFromPipeline=true)]
        public Trigger Trigger
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Function", ValueFromPipeline = true)]
        public Function Function
        {
            get;
            set;
        }

        [Parameter(Position=0)]
        public string Line
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "Trigger":
                    Trigger.CodeLines.Add(Line);
                    break;
                case "Function":
                    Function.CodeLines.Add(Line);
                    break;
            }
        }
    }
}
