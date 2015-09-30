using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeParameter")]
    public class AddCBreezeCodeParameter : AddCBreezeParameter<CodeParameter>
    {
        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? DataLength
        {
            get;
            set;
        }

        protected override CodeParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new CodeParameter(Var, GetParameterID(inputObject), Name, DataLength));
        }
    }
}
