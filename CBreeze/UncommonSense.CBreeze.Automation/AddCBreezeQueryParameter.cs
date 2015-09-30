using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeQueryParameter")]
    public class AddCBreezeQueryParameter : AddCBreezeParameter<QueryParameter>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        [Parameter()]
        public QuerySecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        protected override QueryParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new QueryParameter(Var, GetParameterID(inputObject), Name, SubType));
        }

        protected override void SetParameterProperties(QueryParameter parameter)
        {
            base.SetParameterProperties(parameter);
            parameter.SecurityFiltering = SecurityFiltering;
        }
    }
}
