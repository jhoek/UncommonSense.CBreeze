using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePageParameter")]
    public class AddCBreezePageParameter : AddCBreezeParameter<PageParameter>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        protected override PageParameter CreateParameter()
        {
            return Parameters.Add(new PageParameter(Var, GetParameterID(), Name, SubType));
        }
    }
}
