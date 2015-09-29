using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTimeParameter")]
    public class AddCBreezeTimeParameter : AddCBreezeParameter<TimeParameter>
    {
        protected override TimeParameter CreateParameter()
        {
            return Parameters.Add(new TimeParameter(Var, GetParameterID(), Name));
        }
    }
}
