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

        protected override System.Collections.IEnumerable AddedObjects
        {
            get
            {
                ID = AutoAssignID(ID);

                var automationParameter = Parameters.Add(new AutomationParameter(Var, ID, Name, SubType));
                automationParameter.Dimensions = Dimensions;
                yield return automationParameter;
            }
        }
    }
}
