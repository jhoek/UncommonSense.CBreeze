using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeKeyRefParameter")]
    public class AddCBreezeKeyRefParameter : AddCBreezeParameter<KeyRefParameter>
    {
        protected override KeyRefParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new KeyRefParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
