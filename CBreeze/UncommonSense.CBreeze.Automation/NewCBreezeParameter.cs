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
                    return new ActionParameter(Var, ID, Name);

                case ParameterType.Automation:
                    return new AutomationParameter(Var, ID, Name, StringSubType.Value);

                case ParameterType.BigInteger:
                    return new BigIntegerParameter(Var, ID, Name);

                case ParameterType.BigText:
                    return new BigTextParameter(Var, ID, Name);

                case ParameterType.Binary:
                    return new BinaryParameter(Var, ID, Name, MandatoryDataLength.Value);

                case ParameterType.Boolean:
                    return new BooleanParameter(Var, ID, Name);

                case ParameterType.Byte:
                    return new ByteParameter(Var, ID, Name);

                case ParameterType.Char:
                    return new CharParameter(Var, ID, Name);

                case ParameterType.Code:
                    return new CodeParameter(Var, ID, Name, OptionalDataLength.Value);

                case ParameterType.Codeunit:
                    return new CodeunitParameter(Var, ID, Name, IntegerSubType.Value);

                case ParameterType.Date:
                    return new DateParameter(Var, ID, Name);

                case ParameterType.DateFormula:
                    return new DateFormulaParameter(Var, ID, Name);

                case ParameterType.DateTime:
                    return new DateTimeParameter(Var, ID, Name);

                case ParameterType.Decimal:
                    return new DecimalParameter(Var, ID, Name);

                case ParameterType.Dialog:
                    return new DialogParameter(Var, ID, Name);

                case ParameterType.DotNet:
                    var dotnetParameter = new DotNetParameter(Var, ID, Name, StringSubType.Value);
                    dotnetParameter.RunOnClient = RunOnClient.Value;
                    dotnetParameter.SuppressDispose = SuppressDispose.Value;
                    return dotnetParameter;

                case ParameterType.Duration:
                    return new DurationParameter(Var, ID, Name);

                case ParameterType.ExecutionMode:
                    return new ExecutionModeParameter(Var, ID, Name);

                case ParameterType.FieldRef:
                    return new FieldRefParameter(Var, ID, Name);

                case ParameterType.File:
                    return new FileParameter(Var, ID, Name);

                case ParameterType.Guid:
                    return new GuidParameter(Var, ID, Name);

                case ParameterType.InStream:
                    return new InStreamParameter(Var, ID, Name);

                case ParameterType.Integer:
                    return new IntegerParameter(Var, ID, Name);

                case ParameterType.KeyRef:
                    return new KeyRefParameter(Var, ID, Name);

                case ParameterType.Ocx:
                    return new OcxParameter(Var, ID, Name, StringSubType.Value);

                case ParameterType.Option:
                    var optionParameter = new OptionParameter(Var, ID, Name);
                    optionParameter.OptionString = OptionString.Value;
                    return optionParameter;

                case ParameterType.OutStream:
                    return new OutStreamParameter(Var, ID, Name);

                case ParameterType.Page:
                    return new PageParameter(Var, ID, Name, IntegerSubType.Value);

                case ParameterType.Query:
                    var queryParameter = new QueryParameter(Var, ID, Name, IntegerSubType.Value);
                    queryParameter.SecurityFiltering = QuerySecurityFiltering.Value;
                    return queryParameter;

                case ParameterType.RecordID:
                    return new RecordIDParameter(Var, ID, Name);

                case ParameterType.Record:
                    var recordParameter = new RecordParameter(Var, ID, Name, IntegerSubType.Value);
                    recordParameter.SecurityFiltering = RecordSecurityFiltering.Value;
                    recordParameter.Temporary = Temporary.Value;
                    return recordParameter;

                case ParameterType.RecordRef:
                    var recordRefParameter = new RecordRefParameter(Var, ID, Name);
                    recordRefParameter.SecurityFiltering = RecordSecurityFiltering.Value;
                    return recordRefParameter;

                case ParameterType.Report:
                    return new ReportParameter(Var, ID, Name, IntegerSubType.Value);

#if NAV2016
                case ParameterType.ReportFormat:
                    return new ReportFormatParameter(Var, ID, Name);

                case ParameterType.TableConnectionType:
                    return new TableConnectionTypeParameter(Var, ID, Name);
#endif

                case ParameterType.TestPage:
                    return new TestPageParameter(Var, ID, Name, IntegerSubType.Value);

                case ParameterType.TestRequestPage:
                    return new TestRequestPageParameter(Var, ID, Name, IntegerSubType.Value);

                case ParameterType.Text:
                    return new TextParameter(Var, ID, Name, OptionalDataLength.Value);

#if NAV2016
                case ParameterType.TextEncoding:
                    return new TextEncodingParameter(Var, ID, Name);
#endif

                case ParameterType.Time:
                    return new TimeParameter(Var, ID, Name);

                case ParameterType.TransactionType:
                    return new TransactionTypeParameter(Var, ID, Name);

                case ParameterType.Variant:
                    return new VariantParameter(Var, ID, Name);

                case ParameterType.XmlPort:
                    return new XmlPortParameter(Var, ID, Name, IntegerSubType.Value);

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
