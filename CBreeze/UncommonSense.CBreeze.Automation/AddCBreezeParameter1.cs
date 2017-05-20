using System;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeActionParameter")]
    [OutputType(typeof(ActionParameter))]
    [Alias("ActionParameter")]
    public class AddCBreezeActionParameter : NewNamedItemCmdlet<ActionParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(ActionParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override ActionParameter CreateItem()
        {
            var actionParameter = new ActionParameter(Name, Var, ID);
            actionParameter.Dimensions = Dimensions;
            return actionParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeAutomationParameter")]
    [OutputType(typeof(AutomationParameter))]
    [Alias("AutomationParameter")]
    public class AddCBreezeAutomationParameter : NewNamedItemCmdlet<AutomationParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public string SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(AutomationParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override AutomationParameter CreateItem()
        {
            var automationParameter = new AutomationParameter(Name, SubType, Var, ID);
            automationParameter.Dimensions = Dimensions;
            return automationParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerParameter")]
    [OutputType(typeof(BigIntegerParameter))]
    [Alias("BigIntegerParameter")]
    public class AddCBreezeBigIntegerParameter : NewNamedItemCmdlet<BigIntegerParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(BigIntegerParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override BigIntegerParameter CreateItem()
        {
            var bigIntegerParameter = new BigIntegerParameter(Name, Var, ID);
            bigIntegerParameter.Dimensions = Dimensions;
            return bigIntegerParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeBigTextParameter")]
    [OutputType(typeof(BigTextParameter))]
    [Alias("BigTextParameter")]
    public class AddCBreezeBigTextParameter : NewNamedItemCmdlet<BigTextParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(BigTextParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override BigTextParameter CreateItem()
        {
            var bigTextParameter = new BigTextParameter(Name, Var, ID);
            bigTextParameter.Dimensions = Dimensions;
            return bigTextParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeBinaryParameter")]
    [OutputType(typeof(BinaryParameter))]
    [Alias("BinaryParameter")]
    public class AddCBreezeBinaryParameter : NewNamedItemCmdlet<BinaryParameter, PSObject>
    {
        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int DataLength { get; set; }

        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(BinaryParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override BinaryParameter CreateItem()
        {
            var binaryParameter = new BinaryParameter(Name, Var, ID, DataLength);
            binaryParameter.Dimensions = Dimensions;
            return binaryParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeBooleanParameter")]
    [OutputType(typeof(BooleanParameter))]
    [Alias("BooleanParameter")]
    public class AddCBreezeBooleanParameter : NewNamedItemCmdlet<BooleanParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(BooleanParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override BooleanParameter CreateItem()
        {
            var booleanParameter = new BooleanParameter(Name, Var, ID);
            booleanParameter.Dimensions = Dimensions;
            return booleanParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeByteParameter")]
    [OutputType(typeof(ByteParameter))]
    [Alias("ByteParameter")]
    public class AddCBreezeByteParameter : NewNamedItemCmdlet<ByteParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(ByteParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override ByteParameter CreateItem()
        {
            var byteParameter = new ByteParameter(Name, Var, ID);
            byteParameter.Dimensions = Dimensions;
            return byteParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeCharParameter")]
    [OutputType(typeof(CharParameter))]
    [Alias("CharParameter")]
    public class AddCBreezeCharParameter : NewNamedItemCmdlet<CharParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(CharParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override CharParameter CreateItem()
        {
            var charParameter = new CharParameter(Name, Var, ID);
            charParameter.Dimensions = Dimensions;
            return charParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeCodeParameter")]
    [OutputType(typeof(CodeParameter))]
    [Alias("CodeParameter")]
    public class AddCBreezeCodeParameter : NewNamedItemCmdlet<CodeParameter, PSObject>
    {
        [Parameter(Mandatory = false)]
        [ValidateRange(1, int.MaxValue)]
        public int DataLength { get; set; }

        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(CodeParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override CodeParameter CreateItem()
        {
            var codeParameter = new CodeParameter(Name, Var, ID, DataLength);
            codeParameter.Dimensions = Dimensions;
            return codeParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeCodeunitParameter")]
    [OutputType(typeof(CodeunitParameter))]
    [Alias("CodeunitParameter")]
    public class AddCBreezeCodeunitParameter : NewNamedItemCmdlet<CodeunitParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(CodeunitParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override CodeunitParameter CreateItem()
        {
            var codeunitParameter = new CodeunitParameter(Name, SubType, Var, ID);
            codeunitParameter.Dimensions = Dimensions;
            return codeunitParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDateFormulaParameter")]
    [OutputType(typeof(DateFormulaParameter))]
    [Alias("DateFormulaParameter")]
    public class AddCBreezeDateFormulaParameter : NewNamedItemCmdlet<DateFormulaParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DateFormulaParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DateFormulaParameter CreateItem()
        {
            var dateFormulaParameter = new DateFormulaParameter(Name, Var, ID);
            dateFormulaParameter.Dimensions = Dimensions;
            return dateFormulaParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDateParameter")]
    [OutputType(typeof(DateParameter))]
    [Alias("DateParameter")]
    public class AddCBreezeDateParameter : NewNamedItemCmdlet<DateParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DateParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DateParameter CreateItem()
        {
            var dateParameter = new DateParameter(Name, Var, ID);
            dateParameter.Dimensions = Dimensions;
            return dateParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDateTimeParameter")]
    [OutputType(typeof(DateTimeParameter))]
    [Alias("DateTimeParameter")]
    public class AddCBreezeDateTimeParameter : NewNamedItemCmdlet<DateTimeParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DateTimeParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DateTimeParameter CreateItem()
        {
            var dateTimeParameter = new DateTimeParameter(Name, Var, ID);
            dateTimeParameter.Dimensions = Dimensions;
            return dateTimeParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDecimalParameter")]
    [OutputType(typeof(DecimalParameter))]
    [Alias("DecimalParameter")]
    public class AddCBreezeDecimalParameter : NewNamedItemCmdlet<DecimalParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DecimalParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DecimalParameter CreateItem()
        {
            var decimalParameter = new DecimalParameter(Name, Var, ID);
            decimalParameter.Dimensions = Dimensions;
            return decimalParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDialogParameter")]
    [OutputType(typeof(DialogParameter))]
    [Alias("DialogParameter")]
    public class AddCBreezeDialogParameter : NewNamedItemCmdlet<DialogParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DialogParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DialogParameter CreateItem()
        {
            var dialogParameter = new DialogParameter(Name, Var, ID);
            dialogParameter.Dimensions = Dimensions;
            return dialogParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDotNetParameter")]
    [OutputType(typeof(DotNetParameter))]
    [Alias("DotNetParameter")]
    public class AddCBreezeDotNetParameter : NewNamedItemCmdlet<DotNetParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public string SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DotNetParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DotNetParameter CreateItem()
        {
            var dotNetParameter = new DotNetParameter(Name, SubType, Var, ID);
            dotNetParameter.Dimensions = Dimensions;
            return dotNetParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeDurationParameter")]
    [OutputType(typeof(DurationParameter))]
    [Alias("DurationParameter")]
    public class AddCBreezeDurationParameter : NewNamedItemCmdlet<DurationParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(DurationParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override DurationParameter CreateItem()
        {
            var durationParameter = new DurationParameter(Name, Var, ID);
            durationParameter.Dimensions = Dimensions;
            return durationParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeExecutionModeParameter")]
    [OutputType(typeof(ExecutionModeParameter))]
    [Alias("ExecutionModeParameter")]
    public class AddCBreezeExecutionModeParameter : NewNamedItemCmdlet<ExecutionModeParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(ExecutionModeParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override ExecutionModeParameter CreateItem()
        {
            var executionModeParameter = new ExecutionModeParameter(Name, Var, ID);
            executionModeParameter.Dimensions = Dimensions;
            return executionModeParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeFieldRefParameter")]
    [OutputType(typeof(FieldRefParameter))]
    [Alias("FieldRefParameter")]
    public class AddCBreezeFieldRefParameter : NewNamedItemCmdlet<FieldRefParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(FieldRefParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override FieldRefParameter CreateItem()
        {
            var fieldRefParameter = new FieldRefParameter(Name, Var, ID);
            fieldRefParameter.Dimensions = Dimensions;
            return fieldRefParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeFileParameter")]
    [OutputType(typeof(FileParameter))]
    [Alias("FileParameter")]
    public class AddCBreezeFileParameter : NewNamedItemCmdlet<FileParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(FileParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override FileParameter CreateItem()
        {
            var fileParameter = new FileParameter(Name, Var, ID);
            fileParameter.Dimensions = Dimensions;
            return fileParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeFilterPageBuilderParameter")]
    [OutputType(typeof(FilterPageBuilderParameter))]
    [Alias("FilterPageBuilderParameter")]
    public class AddCBreezeFilterPageBuilderParameter : NewNamedItemCmdlet<FilterPageBuilderParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(FilterPageBuilderParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override FilterPageBuilderParameter CreateItem()
        {
            var filterPageBuilderParameter = new FilterPageBuilderParameter(Name, Var, ID);
            filterPageBuilderParameter.Dimensions = Dimensions;
            return filterPageBuilderParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeGuidParameter")]
    [OutputType(typeof(GuidParameter))]
    [Alias("GuidParameter")]
    public class AddCBreezeGuidParameter : NewNamedItemCmdlet<GuidParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(GuidParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override GuidParameter CreateItem()
        {
            var guidParameter = new GuidParameter(Name, Var, ID);
            guidParameter.Dimensions = Dimensions;
            return guidParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeInStreamParameter")]
    [OutputType(typeof(InStreamParameter))]
    [Alias("InStreamParameter")]
    public class AddCBreezeInStreamParameter : NewNamedItemCmdlet<InStreamParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(InStreamParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override InStreamParameter CreateItem()
        {
            var inStreamParameter = new InStreamParameter(Name, Var, ID);
            inStreamParameter.Dimensions = Dimensions;
            return inStreamParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeIntegerParameter")]
    [OutputType(typeof(IntegerParameter))]
    [Alias("IntegerParameter")]
    public class AddCBreezeIntegerParameter : NewNamedItemCmdlet<IntegerParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(IntegerParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override IntegerParameter CreateItem()
        {
            var integerParameter = new IntegerParameter(Name, Var, ID);
            integerParameter.Dimensions = Dimensions;
            return integerParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeKeyRefParameter")]
    [OutputType(typeof(KeyRefParameter))]
    [Alias("KeyRefParameter")]
    public class AddCBreezeKeyRefParameter : NewNamedItemCmdlet<KeyRefParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(KeyRefParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override KeyRefParameter CreateItem()
        {
            var keyRefParameter = new KeyRefParameter(Name, Var, ID);
            keyRefParameter.Dimensions = Dimensions;
            return keyRefParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeOcxParameter")]
    [OutputType(typeof(OcxParameter))]
    [Alias("OcxParameter")]
    public class AddCBreezeOcxParameter : NewNamedItemCmdlet<OcxParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public string SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(OcxParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override OcxParameter CreateItem()
        {
            var ocxParameter = new OcxParameter(Name, SubType, Var, ID);
            ocxParameter.Dimensions = Dimensions;
            return ocxParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeOptionParameter")]
    [OutputType(typeof(OptionParameter))]
    [Alias("OptionParameter")]
    public class AddCBreezeOptionParameter : NewNamedItemCmdlet<OptionParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public string OptionString { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(OptionParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override OptionParameter CreateItem()
        {
            var optionParameter = new OptionParameter(Name, Var, ID);
            optionParameter.Dimensions = Dimensions;
            optionParameter.OptionString = OptionString; return optionParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeOutStreamParameter")]
    [OutputType(typeof(OutStreamParameter))]
    [Alias("OutStreamParameter")]
    public class AddCBreezeOutStreamParameter : NewNamedItemCmdlet<OutStreamParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(OutStreamParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override OutStreamParameter CreateItem()
        {
            var outStreamParameter = new OutStreamParameter(Name, Var, ID);
            outStreamParameter.Dimensions = Dimensions;
            return outStreamParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezePageParameter")]
    [OutputType(typeof(PageParameter))]
    [Alias("PageParameter")]
    public class AddCBreezePageParameter : NewNamedItemCmdlet<PageParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(PageParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override PageParameter CreateItem()
        {
            var pageParameter = new PageParameter(Name, SubType, Var, ID);
            pageParameter.Dimensions = Dimensions;
            return pageParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeQueryParameter")]
    [OutputType(typeof(QueryParameter))]
    [Alias("QueryParameter")]
    public class AddCBreezeQueryParameter : NewNamedItemCmdlet<QueryParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public QuerySecurityFiltering? SecurityFiltering { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(QueryParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override QueryParameter CreateItem()
        {
            var queryParameter = new QueryParameter(Name, SubType, Var, ID);
            queryParameter.Dimensions = Dimensions;
            queryParameter.SecurityFiltering = SecurityFiltering;
            return queryParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeRecordIDParameter")]
    [OutputType(typeof(RecordIDParameter))]
    [Alias("RecordIDParameter")]
    public class AddCBreezeRecordIDParameter : NewNamedItemCmdlet<RecordIDParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(RecordIDParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override RecordIDParameter CreateItem()
        {
            var recordIDParameter = new RecordIDParameter(Name, Var, ID);
            recordIDParameter.Dimensions = Dimensions;
            return recordIDParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeRecordParameter")]
    [OutputType(typeof(RecordParameter))]
    [Alias("RecordParameter")]
    public class AddCBreezeRecordParameter : NewNamedItemCmdlet<RecordParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public RecordSecurityFiltering? SecurityFiltering { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public bool? Temporary { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(RecordParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override RecordParameter CreateItem()
        {
            var recordParameter = new RecordParameter(Name, SubType, Var, ID);
            recordParameter.Dimensions = Dimensions;
            recordParameter.SecurityFiltering = SecurityFiltering;
            recordParameter.Temporary = Temporary; return recordParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeRecordRefParameter")]
    [OutputType(typeof(RecordRefParameter))]
    [Alias("RecordRefParameter")]
    public class AddCBreezeRecordRefParameter : NewNamedItemCmdlet<RecordRefParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public RecordSecurityFiltering? SecurityFiltering { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(RecordRefParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override RecordRefParameter CreateItem()
        {
            var recordRefParameter = new RecordRefParameter(Name, Var, ID);
            recordRefParameter.Dimensions = Dimensions;
            recordRefParameter.SecurityFiltering = SecurityFiltering;
            return recordRefParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeReportFormatParameter")]
    [OutputType(typeof(ReportFormatParameter))]
    [Alias("ReportFormatParameter")]
    public class AddCBreezeReportFormatParameter : NewNamedItemCmdlet<ReportFormatParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(ReportFormatParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override ReportFormatParameter CreateItem()
        {
            var reportFormatParameter = new ReportFormatParameter(Name, Var, ID);
            reportFormatParameter.Dimensions = Dimensions;
            return reportFormatParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeReportParameter")]
    [OutputType(typeof(ReportParameter))]
    [Alias("ReportParameter")]
    public class AddCBreezeReportParameter : NewNamedItemCmdlet<ReportParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(ReportParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override ReportParameter CreateItem()
        {
            var reportParameter = new ReportParameter(Name, SubType, Var, ID);
            reportParameter.Dimensions = Dimensions;
            return reportParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTableConnectionTypeParameter")]
    [OutputType(typeof(TableConnectionTypeParameter))]
    [Alias("TableConnectionTypeParameter")]
    public class AddCBreezeTableConnectionTypeParameter : NewNamedItemCmdlet<TableConnectionTypeParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TableConnectionTypeParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TableConnectionTypeParameter CreateItem()
        {
            var tableConnectionTypeParameter = new TableConnectionTypeParameter(Name, Var, ID);
            tableConnectionTypeParameter.Dimensions = Dimensions;
            return tableConnectionTypeParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTestPageParameter")]
    [OutputType(typeof(TestPageParameter))]
    [Alias("TestPageParameter")]
    public class AddCBreezeTestPageParameter : NewNamedItemCmdlet<TestPageParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TestPageParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TestPageParameter CreateItem()
        {
            var testPageParameter = new TestPageParameter(Name, SubType, Var, ID);
            testPageParameter.Dimensions = Dimensions;
            return testPageParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTestRequestPageParameter")]
    [OutputType(typeof(TestRequestPageParameter))]
    [Alias("TestRequestPageParameter")]
    public class AddCBreezeTestRequestPageParameter : NewNamedItemCmdlet<TestRequestPageParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TestRequestPageParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TestRequestPageParameter CreateItem()
        {
            var testRequestPageParameter = new TestRequestPageParameter(Name, SubType, Var, ID);
            testRequestPageParameter.Dimensions = Dimensions;
            return testRequestPageParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTextEncodingParameter")]
    [OutputType(typeof(TextEncodingParameter))]
    [Alias("TextEncodingParameter")]
    public class AddCBreezeTextEncodingParameter : NewNamedItemCmdlet<TextEncodingParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TextEncodingParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TextEncodingParameter CreateItem()
        {
            var textEncodingParameter = new TextEncodingParameter(Name, Var, ID);
            textEncodingParameter.Dimensions = Dimensions;
            return textEncodingParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTextParameter")]
    [OutputType(typeof(TextParameter))]
    [Alias("TextParameter")]
    public class AddCBreezeTextParameter : NewNamedItemCmdlet<TextParameter, PSObject>
    {
        [Parameter(Mandatory = false)]
        [ValidateRange(1, int.MaxValue)]
        public int DataLength { get; set; }

        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TextParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TextParameter CreateItem()
        {
            var textParameter = new TextParameter(Name, Var, ID, DataLength);
            textParameter.Dimensions = Dimensions;
            return textParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTimeParameter")]
    [OutputType(typeof(TimeParameter))]
    [Alias("TimeParameter")]
    public class AddCBreezeTimeParameter : NewNamedItemCmdlet<TimeParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TimeParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TimeParameter CreateItem()
        {
            var timeParameter = new TimeParameter(Name, Var, ID);
            timeParameter.Dimensions = Dimensions;
            return timeParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeTransactionTypeParameter")]
    [OutputType(typeof(TransactionTypeParameter))]
    [Alias("TransactionTypeParameter")]
    public class AddCBreezeTransactionTypeParameter : NewNamedItemCmdlet<TransactionTypeParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(TransactionTypeParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override TransactionTypeParameter CreateItem()
        {
            var transactionTypeParameter = new TransactionTypeParameter(Name, Var, ID);
            transactionTypeParameter.Dimensions = Dimensions;
            return transactionTypeParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeVariantParameter")]
    [OutputType(typeof(VariantParameter))]
    [Alias("VariantParameter")]
    public class AddCBreezeVariantParameter : NewNamedItemCmdlet<VariantParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(VariantParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override VariantParameter CreateItem()
        {
            var variantParameter = new VariantParameter(Name, Var, ID);
            variantParameter.Dimensions = Dimensions;
            return variantParameter;
        }
    }

    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPortParameter")]
    [OutputType(typeof(XmlPortParameter))]
    [Alias("XmlPortParameter")]
    public class AddCBreezeXmlPortParameter : NewNamedItemCmdlet<XmlPortParameter, PSObject>
    {
        [Parameter()]
        public string Dimensions { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int SubType { get; set; }

        [Parameter()]
        public SwitchParameter Var { get; set; }

        protected override void AddItemToInputObject(XmlPortParameter item, PSObject inputObject)
        {
            inputObject.GetParameters().Add(item);
        }

        protected override XmlPortParameter CreateItem()
        {
            var xmlPortParameter = new XmlPortParameter(Name, SubType, Var, ID);
            xmlPortParameter.Dimensions = Dimensions;
            return xmlPortParameter;
        }
    }
}