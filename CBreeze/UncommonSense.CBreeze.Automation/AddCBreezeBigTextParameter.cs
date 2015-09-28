using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeBigTextParameter")]
    public class AddCBreezeBigTextParameter : AddCBreezeParameter
    {
        protected override void ProcessRecord()
        {
            var parameter = GetParameters().Add(new BigTextParameter(Var, GetParameterID(), Name));

            parameter.Dimensions = Dimensions;

            if (PassThru)
                WriteObject(parameter);
        }
    }
}
