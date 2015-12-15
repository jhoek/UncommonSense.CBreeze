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
            IntegerSubType = new DynamicParameter<int>("SubType", true, minRange: 1, maxRange: int.MaxValue);
            MandatoryDataLength = new DynamicParameter<int>("DataLength", true, minRange: 1, maxRange: 250);
            OptionalDataLength = new DynamicParameter<int>("DataLength", false, minRange: 1, maxRange: 250);
            OptionString = new DynamicParameter<string>("OptionString", false);
            QuerySecurityFiltering = new DynamicParameter<Core.QuerySecurityFiltering?>("SecurityFiltering", false);
            RunOnClient = new DynamicParameter<bool?>("RunOnClient", false);
            StringSubType = new DynamicParameter<string>("SubType", true);
            RecordSecurityFiltering = new DynamicParameter<RecordSecurityFiltering?>("SecurityFiltering", false);
            Temporary = new DynamicParameter<bool?>("Temporary", false);
            Value = new DynamicParameter<string>("Value", true);
            WithEvents = new DynamicParameter<bool?>("WithEvents", false);
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position=2)]
        public VariableType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory=true,Position=0)]
        [Alias("Range")]
        public PSObject ID
        {
            get;set;
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

        protected DynamicParameter<string> OptionString
        {
            get;
            set;
        }

        protected DynamicParameter<QuerySecurityFiltering?> QuerySecurityFiltering
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

        protected DynamicParameter<string> Value
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
            var variable = InputObject.GetVariables().Add(CreateVariable(InputObject));

            if (PassThru)
                WriteObject(variable);
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
                    codeunitVariable.Dimensions = Dimensions.Value;
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

                case VariableType.Integer:
                    var integerVariable = new IntegerVariable(id, Name);
                    integerVariable.Dimensions = Dimensions.Value;
                    integerVariable.IncludeInDataset = IncludeInDataset.Value;
                    return integerVariable;

                case VariableType.KeyRef:
                    var keyRefVariable = new KeyRefVariable(id, Name);
                    keyRefVariable.Dimensions = Dimensions.Value;
                    return keyRefVariable;

                case VariableType.Ocx:
                    var ocxVariable = new OcxVariable(id, Name, StringSubType.Value);
                    ocxVariable.Dimensions = Dimensions.Value;
                    return ocxVariable;

                case VariableType.Option:
                    var optionVariable = new OptionVariable(id, Name);
                    optionVariable.Dimensions = Dimensions.Value;
                    optionVariable.OptionString = OptionString.Value;
                    return optionVariable;

                case VariableType.OutStream:
                    var outStreamVariable = new OutStreamVariable(id, Name);
                    outStreamVariable.Dimensions = Dimensions.Value;
                    return outStreamVariable;

                case VariableType.Page:
                    var pageVariable = new PageVariable(id, Name, IntegerSubType.Value);
                    pageVariable.Dimensions = Dimensions.Value;
                    return pageVariable;

                case VariableType.Query:
                    var queryVariable = new QueryVariable(id, Name, IntegerSubType.Value);
                    queryVariable.Dimensions = Dimensions.Value;
                    queryVariable.SecurityFiltering = QuerySecurityFiltering.Value;
                    return queryVariable;

                case VariableType.Record:
                    var recordVariable = new RecordVariable(id, Name, IntegerSubType.Value);
                    recordVariable.Dimensions = Dimensions.Value;
                    recordVariable.SecurityFiltering = RecordSecurityFiltering.Value;
                    recordVariable.Temporary = Temporary.Value;
                    return recordVariable;

                case VariableType.RecordID:
                    var recordIDVariable = new RecordIDVariable(id, Name);
                    recordIDVariable.Dimensions = Dimensions.Value;
                    return recordIDVariable;

                case VariableType.RecordRef:
                    var recordRefVariable = new RecordRefVariable(id, Name);
                    recordRefVariable.Dimensions = Dimensions.Value;
                    recordRefVariable.SecurityFiltering = RecordSecurityFiltering.Value;
                    return recordRefVariable;

                case VariableType.Report:
                    var reportVariable = new ReportVariable(id, Name, IntegerSubType.Value);
                    reportVariable.Dimensions = Dimensions.Value;
                    return reportVariable;

                case VariableType.TestPage:
                    var testPageVariable = new TestPageVariable(id, Name, IntegerSubType.Value);
                    testPageVariable.Dimensions = Dimensions.Value;
                    return testPageVariable;

                case VariableType.Text:
                    var textVariable = new TextVariable(id, Name, OptionalDataLength.Value);
                    textVariable.Dimensions = Dimensions.Value;
                    textVariable.IncludeInDataset = IncludeInDataset.Value;
                    return textVariable;

                case VariableType.TextConstant:
                    var textConstant = new TextConstant(id, Name);
                    textConstant.Values.Set("ENU", Value.Value);
                    return textConstant;

                case VariableType.Time:
                    var timeVariable = new TimeVariable(id, Name);
                    timeVariable.Dimensions = Dimensions.Value;
                    return timeVariable;

                case VariableType.TransactionType:
                    var transactionTypeVariable = new TransactionTypeVariable(id, Name);
                    transactionTypeVariable.Dimensions = Dimensions.Value;
                    return transactionTypeVariable;

                case VariableType.Variant:
                    var variantVariable = new VariantVariable(id, Name);
                    variantVariable.Dimensions = Dimensions.Value;
                    return variantVariable;

                case VariableType.XmlPort:
                    var xmlPortVariable = new XmlPortVariable(id, Name, IntegerSubType.Value);
                    xmlPortVariable.Dimensions = Dimensions.Value;
                    return xmlPortVariable;

                default:
                    throw new ArgumentOutOfRangeException("Unknown variable type.");
            }
        }

        protected int GetVariableID(PSObject inputObject)
        {
            return ID.GetID(inputObject.GetVariableIDs().Union(inputObject.GetParameterIDs()));
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
                        yield return OptionalDataLength.RuntimeDefinedParameter;
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

                    case VariableType.Integer:
                        yield return IncludeInDataset.RuntimeDefinedParameter;
                        break;

                    case VariableType.Ocx:
                        yield return StringSubType.RuntimeDefinedParameter;
                        break;

                    case VariableType.Option:
                        yield return OptionString.RuntimeDefinedParameter;
                        break;

                    case VariableType.Page:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;

                    case VariableType.Query:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        yield return QuerySecurityFiltering.RuntimeDefinedParameter;
                        break;

                    case VariableType.Record:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        yield return RecordSecurityFiltering.RuntimeDefinedParameter;
                        yield return Temporary.RuntimeDefinedParameter;
                        break;

                    case VariableType.RecordRef:
                        yield return RecordSecurityFiltering.RuntimeDefinedParameter;
                        break;

                    case VariableType.Report:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;

                    case VariableType.TestPage:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;

                    case VariableType.Text:
                        yield return OptionalDataLength.RuntimeDefinedParameter;
                        yield return IncludeInDataset.RuntimeDefinedParameter;
                        break;

                    case VariableType.TextConstant:
                        yield return Value.RuntimeDefinedParameter;
                        break;

                    case VariableType.XmlPort:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                }

                if (Type != VariableType.TextConstant)
                    yield return Dimensions.RuntimeDefinedParameter;
            }
        }
    }
}
