using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeAutomationParameter")]
    public class AddCBreezeAutomationParameter : AddCBreezeParameter
    {
        [Parameter(Mandatory = true)]
        public string SubType
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var parameter = GetParameters().Add(new AutomationParameter(Var, GetParameterID(), Name, SubType));

            parameter.Dimensions = Dimensions;

            if (PassThru)
                WriteObject(parameter);
        }
    }
}
