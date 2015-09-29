using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeRecordParameter")]
    public class AddCBreezeRecordParameter : AddCBreezeParameter<RecordParameter>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType
        {
            get;
            set;
        }

        [Parameter()]
        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        [Parameter()]
        public bool? Temporary
        {
            get;
            set;
        }

        protected override RecordParameter CreateParameter()
        {
            return Parameters.Add(new RecordParameter(Var, GetParameterID(), Name, SubType));
        }

        protected override void SetParameterProperties(RecordParameter parameter)
        {
            base.SetParameterProperties(parameter);

            parameter.SecurityFiltering = SecurityFiltering;
            parameter.Temporary = Temporary;

        }
    }
}
