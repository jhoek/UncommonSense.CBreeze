using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeActionParameter")]
    public class AddCBreezeActionParameter : AddCBreezeParameter
    {
        protected override void ProcessRecord()
        {
            var parameter = GetParameters().Add(new ActionParameter(Var, GetParameterID(), Name));

            parameter.Dimensions = Dimensions;

            if (PassThru)
                WriteObject(parameter);
        }
    }
}
