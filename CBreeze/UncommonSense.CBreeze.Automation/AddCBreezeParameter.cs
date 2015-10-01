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
            DataLength = new DynamicParameter<int?>("DataLength", true, 1, int.MaxValue);
            IntegerSubType = new DynamicParameter<int?>("SubType", true, 1, int.MaxValue);
            RunOnClient = new DynamicParameter<bool?>("RunOnClient", false);
            StringSubType = new DynamicParameter<string>("SubType", true);
            SuppressDispose = new DynamicParameter<bool?>("SuppressDispose", false);
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

        protected DynamicParameter<int?> DataLength
        {
            get;
            set;
        }

        protected DynamicParameter<int?> IntegerSubType
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
                    return new BinaryParameter(Var, id, Name, DataLength.Value.Value);
                case ParameterType.Boolean:
                    return new BooleanParameter(Var, id, Name);
                case ParameterType.Byte:
                    return new ByteParameter(Var, id, Name);
                case ParameterType.Char:
                    return new CharParameter(Var, id, Name);
                case ParameterType.Code:
                    return new CodeParameter(Var, id, Name, DataLength.Value.Value);
                case ParameterType.Codeunit:
                    return new CodeunitParameter(Var, id, Name, IntegerSubType.Value.Value);
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
                        yield return DataLength.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Code:
                        yield return DataLength.RuntimeDefinedParameter;
                        break;
                    case ParameterType.Codeunit:
                        yield return IntegerSubType.RuntimeDefinedParameter;
                        break;
                    case ParameterType.DotNet:
                        yield return StringSubType.RuntimeDefinedParameter;
                        yield return RunOnClient.RuntimeDefinedParameter;
                        yield return SuppressDispose.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
