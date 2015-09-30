using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFileParameter")]
    public class AddCBreezeFileParameter : AddCBreezeParameter<FileParameter>
    {
        protected override FileParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new FileParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
