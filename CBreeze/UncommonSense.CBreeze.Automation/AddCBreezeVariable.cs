using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    // This cmdlet used to have parameter sets for each combination of scope (Global, Function, Trigger, Event) 
    // and variable type (e.g. Record). The scope aspect was controlled by the type of object received
    // via the pipeline (Code, Function, Trigger, Event).

    // Alternatively, we could have accepted a Variables collection instead of the Code, Function, Trigger 
    // and Event objects. However, Variables is an IEnumerable<Variable>, so PowerShell would have 
    // unravelled it. To work around this, users would have needed to put the variables collection in a 
    // single-element array, like this: (,$MyTable.Code.Variables) | Add-CBreezeVariable ...

    // In the original design, users could do this: $MyTable.Code | Add-CBreezeVariable ... or 
    // $MyFunction | Add-CBreezeVariable ... I felt this was more intuitive, even if it implied a more
    // complex set of parametersetnames. 

    // Sadly, however, PowerShell is unable to handle this many unique parameter sets. :(

    [Cmdlet(VerbsCommon.Add, "CBreezeVariable")]
    public class AddCBreezeVariable : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalAction")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalAutomation")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalBigInteger")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalBigText")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalBinary")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalBoolean")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalByte")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalChar")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalCodeunit")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalCode")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDateFormula")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDateTime")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDate")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDecimal")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDialog")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDotNet")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalDuration")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalExecutionMode")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalFieldRef")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalFile")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalGuid")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalInStream")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalInteger")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalKeyRef")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalOcx")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalOption")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalOutStream")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalPage")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalQuery")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalRecordID")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalRecordRef")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalRecord")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalReport")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalTestPage")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalTextConstant")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalText")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalTime")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalTransactionType")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalVariant")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "GlobalXmlPort")]
        public Code Code
        {
            get;
            set;
        }

        // FIXME: Function scope, all variable types
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FunctionOption")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "FunctionRecord")]
        public Function Function
        {
            get;
            set;
        }

        // FIXME: Trigger scope, all variable types
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "TriggerOption")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "TriggerRecord")]
        public Trigger Trigger
        {
            get;
            set;
        }

        // FIXME: Event scope, all variable types
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "EventOption")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "EventRecord")]
        public Event Event
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "GlobalOption", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "FunctionOption", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "TriggerOption", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "EventOption", Position = 0)]
        public SwitchParameter Option
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "GlobalRecord", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "FunctionRecord", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "TriggerRecord", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "EventRecord", Position = 0)]
        public SwitchParameter Record
        {
            get;
            set;
        }

        [Parameter()]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public string Dimensions
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "GlobalOption", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "FunctionOption", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "TriggerOption", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "EventOption", Position = 0)]
        public string OptionString
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "GlobalRecord", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "FunctionRecord", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "TriggerRecord", Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = "EventRecord", Position = 0)]
        public int SubType
        {
            get;
            set;
        }

        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            WriteVerbose(ParameterSetName);

            ID = AutoAssignID(ID);

            switch (Type)
            {
                case VariableType.Option:
                    var optionVariable = Variables.AddOptionVariable(ID, Name);
                    optionVariable.OptionString = OptionString;
                    optionVariable.Dimensions = Dimensions;
                    this.WriteObjectIf(PassThru, optionVariable);
                    break;

                case VariableType.Record:
                    var recordVariable = Variables.AddRecordVariable(ID, Name, SubType);
                    recordVariable.Dimensions = Dimensions;
                    this.WriteObjectIf(PassThru, recordVariable);
                    break;
            }
        }

        private int AutoAssignID(int id)
        {
            if (id != 0)
                return id;

            if (!Variables.Any())
                return 1;

            return Variables.Last().ID + 1;
        }

        protected Variables Variables
        {
            get
            {
                if (ParameterSetName.StartsWith("Global"))
                    return Code.Variables;
                if (ParameterSetName.StartsWith("Function"))
                    return Function.Variables;
                return null;
            }
        }

        protected VariableType Type
        {
            get
            {
                if (ParameterSetName.EndsWith("Option"))
                    return VariableType.Option;
                if (ParameterSetName.EndsWith("Record"))
                    return VariableType.Record;

                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
