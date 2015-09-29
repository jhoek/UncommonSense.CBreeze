using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeInStreamParameter")]
    public class AddCBreezeInStreamParameter : AddCBreezeParameter<InStreamParameter>
    {
        protected override InStreamParameter CreateParameter()
        {
            return Parameters.Add(new InStreamParameter(Var, GetParameterID(), Name));
        }
    }
}
