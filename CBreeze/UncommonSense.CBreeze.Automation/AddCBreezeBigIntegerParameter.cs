using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerParameter")]
    public class AddCBreezeBigIntegerParameter : AddCBreezeParameter<BigIntegerParameter>
    {
        protected override BigIntegerParameter CreateParameter()
        {
            return Parameters.Add(new BigIntegerParameter(Var, GetParameterID(), Name));
        }
    }
}
