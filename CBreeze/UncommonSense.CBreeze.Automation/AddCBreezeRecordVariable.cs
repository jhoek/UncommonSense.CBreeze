using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeRecordVariable")]
    public class AddCBreezeRecordVariable : Cmdlet //: AddCBreezeVariable<RecordVariable>
    {
        [Parameter()]
        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }

        protected override RecordVariable CreateVariable(PSObject inputObject)
        {
            return GetVariables(inputObject).Add(new RecordVariable(GetVariableID(inputObject), Name, SubType));
        }

        protected override void SetVariableProperties(RecordVariable variable)
        {
            variable.Dimensions = Dimensions;
            variable.SecurityFiltering = SecurityFiltering;
            variable.Temporary = Temporary;
        }
    }
}
