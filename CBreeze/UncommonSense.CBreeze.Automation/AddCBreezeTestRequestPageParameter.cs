using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTestRequestPageParameter")]
    public class AddCBreezeTestRequestPageParameter : AddCBreezeParameter<TestRequestPageParameter>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        protected override TestRequestPageParameter CreateParameter()
        {
            return Parameters.Add(new TestRequestPageParameter(Var, GetParameterID(), Name, SubType));
        }
    }
}
