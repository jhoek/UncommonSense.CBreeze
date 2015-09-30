using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeByteParameter")]
    public class AddCBreezeByteParameter : AddCBreezeParameter<ByteParameter>   
    {
        protected override ByteParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new ByteParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
