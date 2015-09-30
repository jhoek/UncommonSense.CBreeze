using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCharParameter")]
    public class AddCBreezeCharParameter : AddCBreezeParameter<CharParameter>
    {
        protected override CharParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new CharParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
