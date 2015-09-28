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
            foreach (var inputObject in InputObject)
            {
                var parameter = GetParameters(inputObject).Add(new CodeParameter(Var, GetParameterID(inputObject), Name, DataLength));
                parameter.Dimensions = Dimensions;

                if (PassThru)
                    WriteObject(parameter);
            }
        }
    }
}
