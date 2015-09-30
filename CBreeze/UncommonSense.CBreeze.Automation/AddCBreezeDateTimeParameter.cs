using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDateTimeParameter")]
    public class AddCBreezeDateTimeParameter : AddCBreezeParameter<DateTimeParameter>
    {
        protected override DateTimeParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new DateTimeParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
