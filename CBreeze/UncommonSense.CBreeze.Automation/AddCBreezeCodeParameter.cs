using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeParameter")]
    public class AddCBreezeCodeParameter : AddCBreezeParameter
    {
        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? DataLength
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var parameter = GetParameters().Add(new CodeParameter(Var, GetParameterID(), Name, DataLength));
            parameter.Dimensions = Dimensions;

            if (PassThru)
                WriteObject(parameter);
        }
    }
}
