using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeRecordRefParameter")]
    public class AddCBreezeRecordRefParameter : AddCBreezeParameter<RecordRefParameter>
    {
        [Parameter()]
        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        protected override RecordRefParameter CreateParameter(PSObject inputObject)
        {
            return GetParameters(inputObject).Add(new RecordRefParameter(Var, GetParameterID(inputObject), Name));
        }

        protected override void SetParameterProperties(RecordRefParameter parameter)
        {
            base.SetParameterProperties(parameter);

            parameter.SecurityFiltering = SecurityFiltering;
        }
    }
}
