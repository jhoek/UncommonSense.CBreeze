using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeExecutionModeParameter")]
    public class AddCBreezeExecutionModeParameter : AddCBreezeParameter<ExecutionModeParameter>
    {
        protected override ExecutionModeParameter CreateParameter()
        {
            return Parameters.Add(new ExecutionModeParameter(Var, GetParameterID(), Name));
        }
    }
}
