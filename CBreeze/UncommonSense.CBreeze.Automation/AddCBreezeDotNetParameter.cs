using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDotNetParameter")]
    public class AddCBreezeDotNetParameter : AddCBreezeParameter<DotNetParameter>
    {
        [Parameter(Mandatory = true)]
        public string SubType
        {
            get;
            set;
        }

        [Parameter()]
        public bool? RunOnClient
        {
            get;
            set;
        }

        [Parameter()]
        public bool? SuppressDispose
        {
            get;
            set;
        }

        protected override DotNetParameter CreateParameter()
        {
            return Parameters.Add(new DotNetParameter(Var, GetParameterID(), Name, SubType));
        }

        protected override void SetParameterProperties(DotNetParameter parameter)
        {
            base.SetParameterProperties(parameter);

            parameter.RunOnClient = RunOnClient;
            parameter.SuppressDispose = SuppressDispose;
        }
    }
}
