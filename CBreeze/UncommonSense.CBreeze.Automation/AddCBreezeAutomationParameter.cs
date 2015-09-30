using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeAutomationParameter")]
    public class AddCBreezeAutomationParameter : AddCBreezeParameter<AutomationParameter>
    {
        [Parameter(Mandatory = true)]
        public string SubType
        {
            get;
            set;
        }

        protected override AutomationParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new AutomationParameter(Var, GetParameterID(inputObject), Name, SubType));
        }
    }
}
