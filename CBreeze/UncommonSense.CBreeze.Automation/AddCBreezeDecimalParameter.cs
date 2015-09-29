using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDecimalParameter")]
    public class AddCBreezeDecimalParameter : AddCBreezeParameter<DecimalParameter>
    {
        protected override DecimalParameter CreateParameter()
        {
            return Parameters.Add(new DecimalParameter(Var, GetParameterID(), Name));
        }
    }
}
