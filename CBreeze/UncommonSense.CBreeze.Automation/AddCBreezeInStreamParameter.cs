using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeInStreamParameter")]
    public class AddCBreezeInStreamParameter : AddCBreezeParameter<InStreamParameter>
    {
        protected override InStreamParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new InStreamParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
