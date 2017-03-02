using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeParameter")]
    [OutputType(typeof(Parameter))]
    public class NewCBreezeParameter : CmdletWithDynamicParams
    {
        public NewCBreezeParameter()
        {
            OptionalDataLength = new DynamicParameter<int>("DataLength", false, minRange: 1, maxRange: int.MaxValue);
            MandatoryDataLength = new DynamicParameter<int>("DataLength", true, minRange: 1, maxRange: int.MaxValue);
            IntegerSubType = new DynamicParameter<int>("SubType", true, minRange: 1, maxRange: int.MaxValue);
            OptionString = new DynamicParameter<string>("OptionString", false);
            QuerySecurityFiltering = new DynamicParameter<Core.QuerySecurityFiltering?>("SecurityFiltering", false);
            RecordSecurityFiltering = new DynamicParameter<Core.RecordSecurityFiltering?>("SecurityFiltering", false);
            RunOnClient = new DynamicParameter<bool?>("RunOnClient", false);
            StringSubType = new DynamicParameter<string>("SubType", true);
            SuppressDispose = new DynamicParameter<bool?>("SuppressDispose", false);
            Temporary = new DynamicParameter<bool?>("Temporary", false);
        }

        [Parameter(Mandatory = true, Position = 2)]
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

        [Parameter(Mandatory = true, Position = 0)]
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
            var parameter = CreateParameter();
            parameter.Dimensions = Dimensions;
            WriteObject(parameter);
        }

        protected Parameter CreateParameter()
        {
            switch (Type)
            {
                case ParameterType.Action:
                    return new ActionParameter(Name, Var, ID);

                case ParameterType.Automation:
                    return new AutomationParameter(Name, StringSubType.Value, Var, ID);

                case ParameterType.BigInteger:
                    return new BigIntegerParameter(Name, Var, ID);

                case ParameterType.BigText:
                    return new BigTextParameter(Name, Var, ID);

                case ParameterType.Binary:
                    return new BinaryParameter(Name, Var, ID, MandatoryDataLength.Value);

                case ParameterType.Boolean:
                    return new BooleanParameter(Name, Var, ID);

                case ParameterType.Byte:
                    return new ByteParameter(Name, Var, ID);

                case ParameterType.Char:
                    return new CharParameter(Name, Var, ID);

                case ParameterType.Code:
                    return new CodeParameter(Name, Var, ID, OptionalDataLength.Value);

                case ParameterType.Codeunit:
                    return new CodeunitParameter(Name, IntegerSubType.Value, Var, ID);

                case ParameterType.Date:
                    return new DateParameter(Name, Var, ID);

                case ParameterType.DateFormula:
                    return new DateFormulaParameter(Name, Var, ID);

                case ParameterType.DateTime:
                    return new DateTimeParameter(Name, Var, ID);

                case ParameterType.Decimal:
                    return new DecimalParameter(Name, Var, ID);

                case ParameterType.Dialog:
                    return new DialogParameter(Name, Var, ID);

                case ParameterType.DotNet:
                    var dotnetParameter = new DotNetParameter(Name, StringSubType.Value, Var, ID);
                    dotnetParameter.RunOnClient = RunOnClient.Value;
                    dotnetParameter.SuppressDispose = SuppressDispose.Value;
                    return dotnetParameter;

                case ParameterType.Duration:
                    return new DurationParameter(Name, Var, ID);

                case ParameterType.ExecutionMode:
                    return new ExecutionModeParameter(Name, Var, ID);

                case ParameterType.FieldRef:
                    return new FieldRefParameter(Name, Var, ID);

                case ParameterType.File:
                    return new FileParameter(Name, Var, ID);

                case ParameterType.Guid:
                    return new GuidParameter(Name, Var, ID);

                case ParameterType.InStream:
                    return new InStreamParameter(Name, Var, ID);

                case ParameterType.Integer:
                    return new IntegerParameter(Name, Var, ID);

                case ParameterType.KeyRef:
                    return new KeyRefParameter(Name, Var, ID);

                case ParameterType.Ocx:
                    return new OcxParameter(Name, StringSubType.Value, Var, ID);

                case ParameterType.Option:
                    var optionParameter = new OptionParameter(Name, Var, ID);
                    optionParameter.OptionString = OptionString.Value;
                    return optionParameter;

                case ParameterType.OutStream:
                    return new OutStreamParameter(Name, Var, ID);

                case ParameterType.Page:
                    return new PageParameter(Name, IntegerSubType.Value, Var, ID);

                case ParameterType.Query:
                    var queryParameter = new QueryParameter(Name, IntegerSubType.Value, Var, ID);
                    queryParameter.SecurityFiltering = QuerySecurityFiltering.Value;
                    return queryParameter;

                case ParameterType.RecordID:
                    return new RecordIDParameter(Name, Var, ID);

                case ParameterType.Record:
                    var recordParameter = new RecordParameter(Name, IntegerSubType.Value, Var, ID);
                    recordParameter.SecurityFiltering = RecordSecurityFiltering.Value;
                    recordParameter.Temporary = Temporary.Value;
                    return recordParameter;

                case ParameterType.RecordRef:
                    var recordRefParameter = new RecordRefParameter(Name, Var, ID);
                    recordRefParameter.SecurityFiltering = RecordSecurityFiltering.Value;
                    return recordRefParameter;

                case ParameterType.Report:
                    return new ReportParameter(Name, IntegerSubType.Value, Var, ID);

#if NAV2016
                case ParameterType.ReportFormat:
                    return new ReportFormatParameter(Name, Var, ID);

                case ParameterType.TableConnectionType:
                    return new TableConnectionTypeParameter(Name, Var, ID);
#endif

                case ParameterType.TestPage:
                    return new TestPageParameter(Name, IntegerSubType.Value, Var, ID);

                case ParameterType.TestRequestPage:
                    return new TestRequestPageParameter(Name, IntegerSubType.Value, Var, ID);

                case ParameterType.Text:
                    return new TextParameter(Name, Var, ID, OptionalDataLength.Value);

#if NAV2016
                case ParameterType.TextEncoding:
                    return new TextEncodingParameter(Name, Var, ID);
#endif

                case ParameterType.Time:
                    return new TimeParameter(Name, Var, ID);

                case ParameterType.TransactionType:
                    return new TransactionTypeParameter(Name, Var, ID);

                case ParameterType.Variant:
                    return new VariantParameter(Name, Var, ID);

                case ParameterType.XmlPort:
                    return new XmlPortParameter(Name, IntegerSubType.Value, Var, ID);

                default:
                    throw new ArgumentOutOfRangeException("Unknown parameter type.");
            }
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