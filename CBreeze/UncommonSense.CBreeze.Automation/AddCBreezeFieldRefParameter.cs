using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeFieldRefParameter")]
    public class AddCBreezeFieldRefParameter : AddCBreezeParameter<FieldRefParameter>
    {
        protected override FieldRefParameter CreateParameter()
        {
            return Parameters.Add(new FieldRefParameter(Var, GetParameterID(), Name));
        }
    }
}
