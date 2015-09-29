using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeVariantParameter")]
    public class AddCBreezeVariantParameter : AddCBreezeParameter<VariantParameter>
    {
        protected override VariantParameter CreateParameter()
        {
            return Parameters.Add(new VariantParameter(Var, GetParameterID(), Name));
        }
    }
}
