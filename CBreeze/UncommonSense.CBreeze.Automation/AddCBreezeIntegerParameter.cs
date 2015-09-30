using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeIntegerParameter")]
    public class AddCBreezeIntegerParameter : AddCBreezeParameter<IntegerParameter>
    {
        protected override IntegerParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new IntegerParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
