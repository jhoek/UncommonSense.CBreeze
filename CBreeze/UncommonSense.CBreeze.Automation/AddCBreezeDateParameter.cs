using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDateParameter")]
    public class AddCBreezeDateParameter : AddCBreezeParameter<DateParameter>
    {
        protected override DateParameter CreateParameter()
        {
            return Parameters.Add(new DateParameter(Var, GetParameterID(), Name));
        }
    }
}
