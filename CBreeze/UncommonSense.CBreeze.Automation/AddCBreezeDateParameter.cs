using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDateParameter")]
    public class AddCBreezeDateParameter : AddCBreezeParameter<DateParameter>
    {
        protected override DateParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new DateParameter(Var, GetParameterID(inputObject), Name));
        }
    }
}
