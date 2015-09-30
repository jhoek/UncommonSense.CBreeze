using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDurationParameter")]
    public class AddCBreezeDurationParameter : AddCBreezeParameter<DurationParameter>
    {
        protected override DurationParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new DurationParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
