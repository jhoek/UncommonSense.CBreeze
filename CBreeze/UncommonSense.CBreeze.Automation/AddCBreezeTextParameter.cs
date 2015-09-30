using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeTextParameter")]
    public class AddCBreezeTextParameter : AddCBreezeParameter<TextParameter>
    {
        [Parameter()]
        [ValidateRange(1, int.MaxValue)]
        public int? DataLength
        {
            get;
            set;
        }

        protected override TextParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new TextParameter(Var, GetParameterID(inputObject), Name, DataLength));
        }
    }
}
