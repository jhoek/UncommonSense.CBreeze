using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeGuidParameter")]
    public class AddCBreezeGuidParameter : AddCBreezeParameter<GuidParameter>
    {
        protected override GuidParameter CreateParameter()
        {
            return Parameters.Add(new GuidParameter(Var, GetParameterID(), Name));
        }
    }
}
