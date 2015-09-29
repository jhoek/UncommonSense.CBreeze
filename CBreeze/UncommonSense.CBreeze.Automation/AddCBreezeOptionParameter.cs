using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeOptionParameter")]
    public class AddCBreezeOptionParameter : AddCBreezeParameter<OptionParameter>
    {
        [Parameter()]
        public string OptionString
        {
            get;
            set;
        }

        protected override OptionParameter CreateParameter()
        {
            return Parameters.Add(new OptionParameter(Var, GetParameterID(), Name));
        }

        protected override void SetParameterProperties(OptionParameter parameter)
        {
            base.SetParameterProperties(parameter);

            parameter.OptionString = OptionString;
        }
    }
}
