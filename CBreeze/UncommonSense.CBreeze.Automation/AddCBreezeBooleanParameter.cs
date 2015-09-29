using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBooleanParameter")]
    public class AddCBreezeBooleanParameter : AddCBreezeParameter<BooleanParameter>
    {
        protected override BooleanParameter CreateParameter()
        {
            return Parameters.Add(new BooleanParameter(Var, GetParameterID(), Name));
        }
    }
}
