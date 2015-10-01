using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeVariable")]
    public class AddCBreezeVariable : CmdletWithDynamicParams
    {
        public AddCBreezeVariable()
        {
            Dimensions = new DynamicParameter<string>("Dimensions", false);
            IncludeInDataset = new DynamicParameter<bool?>("IncludeInDataset", false);
            IntegerSubType = new DynamicParameter<int>("SubType", true, 1, int.MaxValue);
            MandatoryDataLength = new DynamicParameter<int>("DataLength", true, 1, 250);
            OptionalDataLength = new DynamicParameter<int>("DataLength", false, 1, 250);
            RunOnClient = new DynamicParameter<bool?>("RunOnClient", false);
            StringSubType = new DynamicParameter<string>("SubType", true);
            RecordSecurityFiltering = new DynamicParameter<RecordSecurityFiltering?>("SecurityFiltering", false);
            Temporary = new DynamicParameter<bool?>("Temporary", false);
            WithEvents = new DynamicParameter<bool?>("WithEvents", false);
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject[] InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public VariableType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "Range")]
        public IEnumerable<int> Range
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
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected DynamicParameter<string> Dimensions
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> IncludeInDataset
        {
            get;
            set;
        }

        protected DynamicParameter<int> IntegerSubType
        {
            get;
            set;
        }

        protected DynamicParameter<int> MandatoryDataLength
        {
            get;
            set;
        }

        protected DynamicParameter<int> OptionalDataLength
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> RunOnClient
        {
            get;
            set;
        }

        protected DynamicParameter<string> StringSubType
        {
            get;
            set;
        }

        protected DynamicParameter<RecordSecurityFiltering?> RecordSecurityFiltering
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Temporary
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> WithEvents
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var inputObject in InputObject)
            {
                var variable = inputObject.GetVariables().Add(CreateVariable(inputObject));

                if (PassThru)
                    WriteObject(variable);
            }
        }

        protected Variable CreateVariable(PSObject inputObject)
        {
            var id = GetVariableID(inputObject);

            switch (Type)
            {
                case VariableType.Action:
                    var actionVariable = new ActionVariable(id, Name);
                    actionVariable.Dimensions = Dimensions.Value;
                    return actionVariable;

                case VariableType.Automation:
                    var automationVariable = new AutomationVariable(id, Name, StringSubType.Value);
                    automationVariable.Dimensions = Dimensions.Value;
                    automationVariable.WithEvents = WithEvents.Value;
                    return automationVariable;

                case VariableType.BigInteger:
                    var bigIntegerVariable = new BigIntegerVariable(id, Name);
                    bigIntegerVariable.Dimensions = Dimensions.Value;
                    return bigIntegerVariable;

                case VariableType.BigText:
                    var bigTextVariable = new BigTextVariable(id, Name);
                    bigTextVariable.Dimensions = Dimensions.Value;
                    return bigTextVariable;

                case VariableType.Binary:
                    var binaryVariable = new BinaryVariable(id, Name, MandatoryDataLength.Value);
                    binaryVariable.Dimensions = Dimensions.Value;
                    return binaryVariable;

                case VariableType.Boolean:
                    var booleanVariable = new BooleanVariable(id, Name);
                    booleanVariable.Dimensions = Dimensions.Value;
                    booleanVariable.IncludeInDataset = IncludeInDataset.Value;
                    return booleanVariable;

                case VariableType.Byte:
                    var byteVariable = new ByteVariable(id, Name);
                    byteVariable.Dimensions = Dimensions.Value;
                    return byteVariable;

                case VariableType.Char:
                    var charVariable = new CharVariable(id, Name);
                    charVariable.Dimensions = Dimensions.Value;
                    return charVariable;

                case VariableType.Code:
                    var codeVariable = new CodeVariable(id, Name, OptionalDataLength.Value);
                    codeVariable.Dimensions = Dimensions.Value;
                    codeVariable.IncludeInDataset = IncludeInDataset.Value;
                    return codeVariable;

                case VariableType.Codeunit:
                    var codeunitVariable = new CodeunitVariable(id, Name, IntegerSubType.Value);
                    codeunitVariable.Dimensions = Dimensions.Value  ;
                    return codeunitVariable;
                
                case VariableType.Date:
                    var dateVariable = new DateVariable(id, Name);
                    dateVariable.Dimensions = Dimensions.Value;
                    return dateVariable;
               
                case VariableType.DateFormula:
                    var dateFormulaVariable = new DateFormulaVariable(id, Name);
                    dateFormulaVariable.Dimensions = Dimensions.Value;
                    return dateFormulaVariable;

                case VariableType.DateTime:
                    var dateTimeVariable = new DateTimeVariable(id, Name);
                    dateTimeVariable.Dimensions = Dimensions.Value;
                    return dateTimeVariable;

                case VariableType.Decimal:
                    var decimalVariable = new DecimalVariable(id, Name);
                    decimalVariable.Dimensions = Dimensions.Value;
                    return decimalVariable;

                case VariableType.Dialog:
                    var dialogVariable = new DialogVariable(id, Name);
                    dialogVariable.Dimensions = Dimensions.Value;
                    return dialogVariable;

                case VariableType.DotNet:
                    var dotNetVariable = new DotNetVariable(id, Name, StringSubType.Value);
                    dotNetVariable.Dimensions = Dimensions.Value;
                    dotNetVariable.RunOnClient = RunOnClient.Value;
                    dotNetVariable.WithEvents = WithEvents.Value;
                    return dotNetVariable;

                case VariableType.Duration:
                    var durationVariable = new DurationVariable(id, Name);
                    durationVariable.Dimensions = Dimensions.Value;
                    return durationVariable;

                case VariableType.ExecutionMode:
                    var executionModeVariable = new ExecutionModeVariable(id, Name);
                    executionModeVariable.Dimensions = Dimensions.Value;
                    return executionModeVariable;

                case VariableType.FieldRef:
                    var fieldRefVariable = new FieldRefVariable(id, Name);
                    fieldRefVariable.Dimensions = Dimensions.Value;
                    return fieldRefVariable;

                case VariableType.File:
                    var fileVariable = new FileVariable(id, Name);
                    fileVariable.Dimensions = Dimensions.Value;
                    return fileVariable;

                case VariableType.Guid:
                    var guidVariable = new GuidVariable(id, Name);
                    guidVariable.Dimensions = Dimensions.Value;
                    return guidVariable;

                case VariableType.InStream:
                    var instreamVariable = new InStreamVariable(id, Name);
                    instreamVariable.Dimensions = Dimensions.Value;
                    return instreamVariable;

                case VariableType.Record:
                    var recordVariable = new RecordVariable(id, Name, IntegerSubType.Value);
                    recordVariable.Dimensions = Dimensions.Value;
                    recordVariable.SecurityFiltering = RecordSecurityFiltering.Value;
                    recordVariable.Temporary = Temporary.Value;
                    return recordVariable;

                default:
                    throw new ArgumentOutOfRangeException("Unknown variable type.");
            }
        }

        protected int GetVariableID(PSObject inputObject)
        {
            if (ID != 0)
                return ID;

            return Range.Except(inputObject.GetVariables().Select(v => v.ID)).First();
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case VariableType.Automation:
                        yield return StringSubType.RuntimeDefinedParameter;
                        yield return WithEvents.RuntimeDefinedParameter;
                        break;

                    case VariableType.Binary:
                        yield return MandatoryDataLength.RuntimeDefinedParameter;
                        break;

                    case VariableType.Boolean:
                        yield return IncludeInDataset.RuntimeDefinedParameter;
                        break;

                    case VariableType.Code:
                        yield return IncludeInDataset.RuntimeDefinedParameter;
                        break;

                    case VariableType.Codeunit:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;

                    case VariableType.DotNet:
                        yield return RunOnClient.RuntimeDefinedParameter;
                        yield return StringSubType.RuntimeDefinedParameter;
                        yield return WithEvents.RuntimeDefinedParameter;
                        break;
                    
                    case VariableType.Record:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        yield return RecordSecurityFiltering.RuntimeDefinedParameter;
                        yield return Temporary.RuntimeDefinedParameter;
                        break;
                }

                if (Type != VariableType.TextConstant)
                    yield return Dimensions.RuntimeDefinedParameter;
            }
        }
    }
}
