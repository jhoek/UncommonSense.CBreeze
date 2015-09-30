using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTestPageParameter")]
    public class AddCBreezeTestPageParameter : AddCBreezeParameter<TestPageParameter>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        protected override TestPageParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new TestPageParameter(Var, GetParameterID(inputObject), Name, SubType));
        }
    }
}
