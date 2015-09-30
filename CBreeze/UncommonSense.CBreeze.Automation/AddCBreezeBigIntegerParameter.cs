using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerParameter")]
    public class AddCBreezeBigIntegerParameter : AddCBreezeParameter<BigIntegerParameter>
    {
        protected override BigIntegerParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new BigIntegerParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
