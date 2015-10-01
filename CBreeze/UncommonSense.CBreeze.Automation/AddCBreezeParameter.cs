using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeParameter")]
    public class AddCBreezeParameter : CmdletWithDynamicParams
    {
        public AddCBreezeParameter()
        {
            OptionalDataLength = new DynamicParameter<int>("DataLength", false, 1, int.MaxValue);
            MandatoryDataLength = new DynamicParameter<int>("DataLength", true, 1, int.MaxValue);
            IntegerSubType = new DynamicParameter<int>("SubType", true, 1, int.MaxValue);
            OptionString = new DynamicParameter<string>("OptionString", false);
            QuerySecurityFiltering = new DynamicParameter<Core.QuerySecurityFiltering?>("SecurityFiltering", false);
            RecordSecurityFiltering = new DynamicParameter<Core.RecordSecurityFiltering?>("SecurityFiltering", false);
            RunOnClient = new DynamicParameter<bool?>("RunOnClient", false);
            StringSubType = new DynamicParameter<string>("SubType", true);
            SuppressDispose = new DynamicParameter<bool?>("SuppressDispose", false);
            Temporary = new DynamicParameter<bool?>("Temporary", false);
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject[] InputObject
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public ParameterType? Type
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter Var
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
        public string Dimensions
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

        protected DynamicParameter<int> OptionalDataLength
        {
            get;
            set;
        }

        protected DynamicParameter<int> MandatoryDataLength
        {
            get;
            set;
        }

        protected DynamicParameter<int> IntegerSubType
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

        protected DynamicParameter<RecordSecurityFiltering?> RecordSecurityFiltering
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

        protected DynamicParameter<bool?> SuppressDispose
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Temporary
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            foreach (var inputObject in InputObject)
            {
                var parameter = GetParameters(inputObject).Add(CreateParameter(inputObject));
                parameter.Dimensions = Dimensions;

                if (PassThru)
                    WriteObject(parameter);
            }
        }

        protected Parameter CreateParameter(PSObject inputObject)
        {
            var id = GetParameterID(inputObject);

            switch (Type)
            {
                case ParameterType.Action:
                    return new ActionParameter(Var, id, Name);

                case ParameterType.Automation:
                    return new AutomationParameter(Var, id, Name, StringSubType.Value);

                case ParameterType.BigInteger:
                    return new BigIntegerParameter(Var, id, Name);

                case ParameterType.BigText:
                    return new BigTextParameter(Var, id, Name);

                case ParameterType.Binary:
                    return new BinaryParameter(Var, id, Name, MandatoryDataLength.Value);

                case ParameterType.Boolean:
                    return new BooleanParameter(Var, id, Name);

                case ParameterType.Byte:
                    return new ByteParameter(Var, id, Name);

                case ParameterType.Char:
                    return new CharParameter(Var, id, Name);

                case ParameterType.Code:
                    return new CodeParameter(Var, id, Name, OptionalDataLength.Value);

                case ParameterType.Codeunit:
                    return new CodeunitParameter(Var, id, Name, IntegerSubType.Value);

                case ParameterType.Date:
                    return new DateParameter(Var, id, Name);

                case ParameterType.DateFormula:
                    return new DateFormulaParameter(Var, id, Name);

                case ParameterType.DateTime:
                    return new DateTimeParameter(Var, id, Name);

                case ParameterType.Decimal:
                    return new DecimalParameter(Var, id, Name);

                case ParameterType.Dialog:
                    return new DialogParameter(Var, id, Name);

                case ParameterType.DotNet:
                    var dotnetParameter = new DotNetParameter(Var, id, Name, StringSubType.Value);
                    dotnetParameter.RunOnClient = RunOnClient.Value;
                    dotnetParameter.SuppressDispose = SuppressDispose.Value;
                    return dotnetParameter;

                case ParameterType.Duration:
                    return new DurationParameter(Var, id, Name);

                case ParameterType.ExecutionMode:
                    return new ExecutionModeParameter(Var, id, Name);

                case ParameterType.FieldRef:
                    return new FieldRefParameter(Var, id, Name);

                case ParameterType.File:
                    return new FileParameter(Var, id, Name);

                case ParameterType.Guid:
                    return new GuidParameter(Var, id, Name);

                case ParameterType.InStream:
                    return new InStreamParameter(Var, id, Name);

                case ParameterType.Integer:
                    return new IntegerParameter(Var, id, Name);

                case ParameterType.KeyRef:
                    return new KeyRefParameter(Var, id, Name);

                case ParameterType.Ocx:
                    return new OcxParameter(Var, id, Name, StringSubType.Value);

                case ParameterType.Option:
                    var optionParameter = new OptionParameter(Var, id, Name);
                    optionParameter.OptionString = OptionString.Value;
                    return optionParameter;

                case ParameterType.OutStream:
                    return new OutStreamParameter(Var, id, Name);

                case ParameterType.Page:
                    return new PageParameter(Var, id, Name, IntegerSubType.Value);

                case ParameterType.Query:
                    var queryParameter = new QueryParameter(Var, id, Name, IntegerSubType.Value);
                    queryParameter.SecurityFiltering = QuerySecurityFiltering.Value;
                    return queryParameter;

                case ParameterType.RecordID:
                    return new RecordIDParameter(Var, id, Name);

                case ParameterType.Record:
                    var recordParameter = new RecordParameter(Var, id, Name, IntegerSubType.Value);
                    recordParameter.SecurityFiltering = RecordSecurityFiltering.Value;
                    recordParameter.Temporary = Temporary.Value;
                    return recordParameter;

                case ParameterType.RecordRef:
                    var recordRefParameter = new RecordRefParameter(Var, id, Name);
                    recordRefParameter.SecurityFiltering = RecordSecurityFiltering.Value;
                    return recordRefParameter;

                case ParameterType.Report:
                    return new ReportParameter(Var, id, Name, IntegerSubType.Value);

                case ParameterType.TestPage:
                    return new TestPageParameter(Var, id, Name, IntegerSubType.Value);

                case ParameterType.TestRequestPage:
                    return new TestRequestPageParameter(Var, id, Name, IntegerSubType.Value);

                case ParameterType.Text:
                    return new TextParameter(Var, id, Name, OptionalDataLength.Value);

                case ParameterType.Time:
                    return new TimeParameter(Var, id, Name);

                case ParameterType.TransactionType:
                    return new TransactionTypeParameter(Var, id, Name);

                case ParameterType.Variant:
                    return new VariantParameter(Var, id, Name);

                case ParameterType.XmlPort:
                    return new XmlPortParameter(Var, id, Name, IntegerSubType.Value);

                default:
                    throw new ArgumentOutOfRangeException("Unknown parameter type.");
            }
        }

        protected int GetParameterID(PSObject inputObject)
        {
            if (ID != 0)
                return ID;

            return Range.Except(GetParameters(inputObject).Select(p => p.ID)).First();
        }

        protected Parameters GetParameters(PSObject inputObject)
        {
            if (inputObject.BaseObject is Parameters)
                return (inputObject.BaseObject as Parameters);
            if (inputObject.BaseObject is Function)
                return (inputObject.BaseObject as Function).Parameters;
            if (inputObject.BaseObject is Event)
                return (inputObject.BaseObject as Event).Parameters;

            throw new ApplicationException("Cannot add parameters to this object.");
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case ParameterType.Automation:
                        yield return StringSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Binary:
                        yield return MandatoryDataLength.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Code:
                        yield return OptionalDataLength.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Codeunit:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.DotNet:
                        yield return StringSubType.RuntimeDefinedParameter;
                        yield return RunOnClient.RuntimeDefinedParameter;
                        yield return SuppressDispose.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Ocx:
                        yield return StringSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Option:
                        yield return OptionString.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Page:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Query:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        yield return QuerySecurityFiltering.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Record:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        yield return RecordSecurityFiltering.RuntimeDefinedParameter;
                        yield return Temporary.RuntimeDefinedParameter;
                        break;
                    case ParameterType.RecordRef:
                        yield return RecordSecurityFiltering.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Report:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.TestPage:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.TestRequestPage:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Text:
                        yield return OptionalDataLength.RuntimeDefinedParameter;
                        break;
                    case ParameterType.XmlPort:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
