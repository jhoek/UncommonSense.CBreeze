using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDecimalParameter")]
    public class AddCBreezeDecimalParameter : AddCBreezeParameter<DecimalParameter>
    {
        protected override DecimalParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new DecimalParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
