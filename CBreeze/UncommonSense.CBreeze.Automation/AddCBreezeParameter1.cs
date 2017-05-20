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
	protected override ActionParameter CreateItem()
	{
		var actionParameter = new ActionParameter(Name, Var, ID);
		actionParameter.Dimensions = Dimensions;
		return actionParameter;
	}

	protected override void AddItemToInputObject(ActionParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeAutomationParameter")]
[OutputType(typeof(AutomationParameter))]
[Alias("AutomationParameter")]
public class AddCBreezeAutomationParameter : NewNamedItemCmdlet<AutomationParameter, PSObject>
{
	protected override AutomationParameter CreateItem()
	{
		var automationParameter = new AutomationParameter(Name, SubType, Var, ID);
		automationParameter.Dimensions = Dimensions;
		return automationParameter;
	}

	protected override void AddItemToInputObject(AutomationParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	public string SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeBigIntegerParameter")]
[OutputType(typeof(BigIntegerParameter))]
[Alias("BigIntegerParameter")]
public class AddCBreezeBigIntegerParameter : NewNamedItemCmdlet<BigIntegerParameter, PSObject>
{
	protected override BigIntegerParameter CreateItem()
	{
		var bigIntegerParameter = new BigIntegerParameter(Name, Var, ID);
		bigIntegerParameter.Dimensions = Dimensions;
		return bigIntegerParameter;
	}

	protected override void AddItemToInputObject(BigIntegerParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeBigTextParameter")]
[OutputType(typeof(BigTextParameter))]
[Alias("BigTextParameter")]
public class AddCBreezeBigTextParameter : NewNamedItemCmdlet<BigTextParameter, PSObject>
{
	protected override BigTextParameter CreateItem()
	{
		var bigTextParameter = new BigTextParameter(Name, Var, ID);
		bigTextParameter.Dimensions = Dimensions;
		return bigTextParameter;
	}

	protected override void AddItemToInputObject(BigTextParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeBinaryParameter")]
[OutputType(typeof(BinaryParameter))]
[Alias("BinaryParameter")]
public class AddCBreezeBinaryParameter : NewNamedItemCmdlet<BinaryParameter, PSObject>
{
	protected override BinaryParameter CreateItem()
	{
		var binaryParameter = new BinaryParameter(Name, Var, ID, DataLength);
		binaryParameter.Dimensions = Dimensions;
		return binaryParameter;
	}

	protected override void AddItemToInputObject(BinaryParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int DataLength { get; set; }

	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeBooleanParameter")]
[OutputType(typeof(BooleanParameter))]
[Alias("BooleanParameter")]
public class AddCBreezeBooleanParameter : NewNamedItemCmdlet<BooleanParameter, PSObject>
{
	protected override BooleanParameter CreateItem()
	{
		var booleanParameter = new BooleanParameter(Name, Var, ID);
		booleanParameter.Dimensions = Dimensions;
		return booleanParameter;
	}

	protected override void AddItemToInputObject(BooleanParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeByteParameter")]
[OutputType(typeof(ByteParameter))]
[Alias("ByteParameter")]
public class AddCBreezeByteParameter : NewNamedItemCmdlet<ByteParameter, PSObject>
{
	protected override ByteParameter CreateItem()
	{
		var byteParameter = new ByteParameter(Name, Var, ID);
		byteParameter.Dimensions = Dimensions;
		return byteParameter;
	}

	protected override void AddItemToInputObject(ByteParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeCharParameter")]
[OutputType(typeof(CharParameter))]
[Alias("CharParameter")]
public class AddCBreezeCharParameter : NewNamedItemCmdlet<CharParameter, PSObject>
{
	protected override CharParameter CreateItem()
	{
		var charParameter = new CharParameter(Name, Var, ID);
		charParameter.Dimensions = Dimensions;
		return charParameter;
	}

	protected override void AddItemToInputObject(CharParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeFilterPageBuilderParameter")]
[OutputType(typeof(FilterPageBuilderParameter))]
[Alias("FilterPageBuilderParameter")]
public class AddCBreezeFilterPageBuilderParameter : NewNamedItemCmdlet<FilterPageBuilderParameter, PSObject>
{
	protected override FilterPageBuilderParameter CreateItem()
	{
		var filterPageBuilderParameter = new FilterPageBuilderParameter(Name, Var, ID);
		filterPageBuilderParameter.Dimensions = Dimensions;
		return filterPageBuilderParameter;
	}

	protected override void AddItemToInputObject(FilterPageBuilderParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeCodeParameter")]
[OutputType(typeof(CodeParameter))]
[Alias("CodeParameter")]
public class AddCBreezeCodeParameter : NewNamedItemCmdlet<CodeParameter, PSObject>
{
	protected override CodeParameter CreateItem()
	{
		var codeParameter = new CodeParameter(Name, Var, ID, DataLength);
		codeParameter.Dimensions = Dimensions;
		return codeParameter;
	}

	protected override void AddItemToInputObject(CodeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}

	[Parameter(Mandatory=false)]
	[ValidateRange(1, int.MaxValue)]
	public int DataLength { get; set; }

	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeCodeunitParameter")]
[OutputType(typeof(CodeunitParameter))]
[Alias("CodeunitParameter")]
public class AddCBreezeCodeunitParameter : NewNamedItemCmdlet<CodeunitParameter, PSObject>
{
	protected override CodeunitParameter CreateItem()
	{
		var codeunitParameter = new CodeunitParameter(Name, SubType, Var, ID);
		codeunitParameter.Dimensions = Dimensions;
		return codeunitParameter;
	}

	protected override void AddItemToInputObject(CodeunitParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeDateFormulaParameter")]
[OutputType(typeof(DateFormulaParameter))]
[Alias("DateFormulaParameter")]
public class AddCBreezeDateFormulaParameter : NewNamedItemCmdlet<DateFormulaParameter, PSObject>
{
	protected override DateFormulaParameter CreateItem()
	{
		var dateFormulaParameter = new DateFormulaParameter(Name, Var, ID);
		dateFormulaParameter.Dimensions = Dimensions;
		return dateFormulaParameter;
	}

	protected override void AddItemToInputObject(DateFormulaParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeDateParameter")]
[OutputType(typeof(DateParameter))]
[Alias("DateParameter")]
public class AddCBreezeDateParameter : NewNamedItemCmdlet<DateParameter, PSObject>
{
	protected override DateParameter CreateItem()
	{
		var dateParameter = new DateParameter(Name, Var, ID);
		dateParameter.Dimensions = Dimensions;
		return dateParameter;
	}

	protected override void AddItemToInputObject(DateParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeDateTimeParameter")]
[OutputType(typeof(DateTimeParameter))]
[Alias("DateTimeParameter")]
public class AddCBreezeDateTimeParameter : NewNamedItemCmdlet<DateTimeParameter, PSObject>
{
	protected override DateTimeParameter CreateItem()
	{
		var dateTimeParameter = new DateTimeParameter(Name, Var, ID);
		dateTimeParameter.Dimensions = Dimensions;
		return dateTimeParameter;
	}

	protected override void AddItemToInputObject(DateTimeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeDecimalParameter")]
[OutputType(typeof(DecimalParameter))]
[Alias("DecimalParameter")]
public class AddCBreezeDecimalParameter : NewNamedItemCmdlet<DecimalParameter, PSObject>
{
	protected override DecimalParameter CreateItem()
	{
		var decimalParameter = new DecimalParameter(Name, Var, ID);
		decimalParameter.Dimensions = Dimensions;
		return decimalParameter;
	}

	protected override void AddItemToInputObject(DecimalParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeDialogParameter")]
[OutputType(typeof(DialogParameter))]
[Alias("DialogParameter")]
public class AddCBreezeDialogParameter : NewNamedItemCmdlet<DialogParameter, PSObject>
{
	protected override DialogParameter CreateItem()
	{
		var dialogParameter = new DialogParameter(Name, Var, ID);
		dialogParameter.Dimensions = Dimensions;
		return dialogParameter;
	}

	protected override void AddItemToInputObject(DialogParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeDotNetParameter")]
[OutputType(typeof(DotNetParameter))]
[Alias("DotNetParameter")]
public class AddCBreezeDotNetParameter : NewNamedItemCmdlet<DotNetParameter, PSObject>
{
	protected override DotNetParameter CreateItem()
	{
		var dotNetParameter = new DotNetParameter(Name, SubType, Var, ID);
		dotNetParameter.Dimensions = Dimensions;
		dotNetParameter.RunOnClient = RunOnClient; 		dotNetParameter.SuppressDispose = SuppressDispose; 		return dotNetParameter;
	}

	protected override void AddItemToInputObject(DotNetParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter()]
	public bool? RunOnClient { get; set; }

	[Parameter(Mandatory=true)]
	public string SubType { get; set; }

	[Parameter()]
	public bool? SuppressDispose { get; set; } 
}

[Cmdlet(VerbsCommon.Add, "CBreezeDurationParameter")]
[OutputType(typeof(DurationParameter))]
[Alias("DurationParameter")]
public class AddCBreezeDurationParameter : NewNamedItemCmdlet<DurationParameter, PSObject>
{
	protected override DurationParameter CreateItem()
	{
		var durationParameter = new DurationParameter(Name, Var, ID);
		durationParameter.Dimensions = Dimensions;
		return durationParameter;
	}

	protected override void AddItemToInputObject(DurationParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeExecutionModeParameter")]
[OutputType(typeof(ExecutionModeParameter))]
[Alias("ExecutionModeParameter")]
public class AddCBreezeExecutionModeParameter : NewNamedItemCmdlet<ExecutionModeParameter, PSObject>
{
	protected override ExecutionModeParameter CreateItem()
	{
		var executionModeParameter = new ExecutionModeParameter(Name, Var, ID);
		executionModeParameter.Dimensions = Dimensions;
		return executionModeParameter;
	}

	protected override void AddItemToInputObject(ExecutionModeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeFieldRefParameter")]
[OutputType(typeof(FieldRefParameter))]
[Alias("FieldRefParameter")]
public class AddCBreezeFieldRefParameter : NewNamedItemCmdlet<FieldRefParameter, PSObject>
{
	protected override FieldRefParameter CreateItem()
	{
		var fieldRefParameter = new FieldRefParameter(Name, Var, ID);
		fieldRefParameter.Dimensions = Dimensions;
		return fieldRefParameter;
	}

	protected override void AddItemToInputObject(FieldRefParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeFileParameter")]
[OutputType(typeof(FileParameter))]
[Alias("FileParameter")]
public class AddCBreezeFileParameter : NewNamedItemCmdlet<FileParameter, PSObject>
{
	protected override FileParameter CreateItem()
	{
		var fileParameter = new FileParameter(Name, Var, ID);
		fileParameter.Dimensions = Dimensions;
		return fileParameter;
	}

	protected override void AddItemToInputObject(FileParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeReportFormatParameter")]
[OutputType(typeof(ReportFormatParameter))]
[Alias("ReportFormatParameter")]
public class AddCBreezeReportFormatParameter : NewNamedItemCmdlet<ReportFormatParameter, PSObject>
{
	protected override ReportFormatParameter CreateItem()
	{
		var reportFormatParameter = new ReportFormatParameter(Name, Var, ID);
		reportFormatParameter.Dimensions = Dimensions;
		return reportFormatParameter;
	}

	protected override void AddItemToInputObject(ReportFormatParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTableConnectionTypeParameter")]
[OutputType(typeof(TableConnectionTypeParameter))]
[Alias("TableConnectionTypeParameter")]
public class AddCBreezeTableConnectionTypeParameter : NewNamedItemCmdlet<TableConnectionTypeParameter, PSObject>
{
	protected override TableConnectionTypeParameter CreateItem()
	{
		var tableConnectionTypeParameter = new TableConnectionTypeParameter(Name, Var, ID);
		tableConnectionTypeParameter.Dimensions = Dimensions;
		return tableConnectionTypeParameter;
	}

	protected override void AddItemToInputObject(TableConnectionTypeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeGuidParameter")]
[OutputType(typeof(GuidParameter))]
[Alias("GuidParameter")]
public class AddCBreezeGuidParameter : NewNamedItemCmdlet<GuidParameter, PSObject>
{
	protected override GuidParameter CreateItem()
	{
		var guidParameter = new GuidParameter(Name, Var, ID);
		guidParameter.Dimensions = Dimensions;
		return guidParameter;
	}

	protected override void AddItemToInputObject(GuidParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeInStreamParameter")]
[OutputType(typeof(InStreamParameter))]
[Alias("InStreamParameter")]
public class AddCBreezeInStreamParameter : NewNamedItemCmdlet<InStreamParameter, PSObject>
{
	protected override InStreamParameter CreateItem()
	{
		var inStreamParameter = new InStreamParameter(Name, Var, ID);
		inStreamParameter.Dimensions = Dimensions;
		return inStreamParameter;
	}

	protected override void AddItemToInputObject(InStreamParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeIntegerParameter")]
[OutputType(typeof(IntegerParameter))]
[Alias("IntegerParameter")]
public class AddCBreezeIntegerParameter : NewNamedItemCmdlet<IntegerParameter, PSObject>
{
	protected override IntegerParameter CreateItem()
	{
		var integerParameter = new IntegerParameter(Name, Var, ID);
		integerParameter.Dimensions = Dimensions;
		return integerParameter;
	}

	protected override void AddItemToInputObject(IntegerParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeKeyRefParameter")]
[OutputType(typeof(KeyRefParameter))]
[Alias("KeyRefParameter")]
public class AddCBreezeKeyRefParameter : NewNamedItemCmdlet<KeyRefParameter, PSObject>
{
	protected override KeyRefParameter CreateItem()
	{
		var keyRefParameter = new KeyRefParameter(Name, Var, ID);
		keyRefParameter.Dimensions = Dimensions;
		return keyRefParameter;
	}

	protected override void AddItemToInputObject(KeyRefParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeOcxParameter")]
[OutputType(typeof(OcxParameter))]
[Alias("OcxParameter")]
public class AddCBreezeOcxParameter : NewNamedItemCmdlet<OcxParameter, PSObject>
{
	protected override OcxParameter CreateItem()
	{
		var ocxParameter = new OcxParameter(Name, SubType, Var, ID);
		ocxParameter.Dimensions = Dimensions;
		return ocxParameter;
	}

	protected override void AddItemToInputObject(OcxParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	public string SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeOptionParameter")]
[OutputType(typeof(OptionParameter))]
[Alias("OptionParameter")]
public class AddCBreezeOptionParameter : NewNamedItemCmdlet<OptionParameter, PSObject>
{
	protected override OptionParameter CreateItem()
	{
		var optionParameter = new OptionParameter(Name, Var, ID);
		optionParameter.Dimensions = Dimensions;
		optionParameter.OptionString = OptionString; 		return optionParameter;
	}

	protected override void AddItemToInputObject(OptionParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter()]
	public string OptionString { get;set; } 
}

[Cmdlet(VerbsCommon.Add, "CBreezeOutStreamParameter")]
[OutputType(typeof(OutStreamParameter))]
[Alias("OutStreamParameter")]
public class AddCBreezeOutStreamParameter : NewNamedItemCmdlet<OutStreamParameter, PSObject>
{
	protected override OutStreamParameter CreateItem()
	{
		var outStreamParameter = new OutStreamParameter(Name, Var, ID);
		outStreamParameter.Dimensions = Dimensions;
		return outStreamParameter;
	}

	protected override void AddItemToInputObject(OutStreamParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezePageParameter")]
[OutputType(typeof(PageParameter))]
[Alias("PageParameter")]
public class AddCBreezePageParameter : NewNamedItemCmdlet<PageParameter, PSObject>
{
	protected override PageParameter CreateItem()
	{
		var pageParameter = new PageParameter(Name, SubType, Var, ID);
		pageParameter.Dimensions = Dimensions;
		return pageParameter;
	}

	protected override void AddItemToInputObject(PageParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeQueryParameter")]
[OutputType(typeof(QueryParameter))]
[Alias("QueryParameter")]
public class AddCBreezeQueryParameter : NewNamedItemCmdlet<QueryParameter, PSObject>
{
	protected override QueryParameter CreateItem()
	{
		var queryParameter = new QueryParameter(Name, SubType, Var, ID);
		queryParameter.Dimensions = Dimensions;
		queryParameter.SecurityFiltering = SecurityFiltering; 		return queryParameter;
	}

	protected override void AddItemToInputObject(QueryParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter()]
	public QuerySecurityFiltering? SecurityFiltering { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeRecordIDParameter")]
[OutputType(typeof(RecordIDParameter))]
[Alias("RecordIDParameter")]
public class AddCBreezeRecordIDParameter : NewNamedItemCmdlet<RecordIDParameter, PSObject>
{
	protected override RecordIDParameter CreateItem()
	{
		var recordIDParameter = new RecordIDParameter(Name, Var, ID);
		recordIDParameter.Dimensions = Dimensions;
		return recordIDParameter;
	}

	protected override void AddItemToInputObject(RecordIDParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeRecordParameter")]
[OutputType(typeof(RecordParameter))]
[Alias("RecordParameter")]
public class AddCBreezeRecordParameter : NewNamedItemCmdlet<RecordParameter, PSObject>
{
	protected override RecordParameter CreateItem()
	{
		var recordParameter = new RecordParameter(Name, SubType, Var, ID);
		recordParameter.Dimensions = Dimensions;
		recordParameter.SecurityFiltering = SecurityFiltering; 		recordParameter.Temporary = Temporary; 		return recordParameter;
	}

	protected override void AddItemToInputObject(RecordParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter()]
	public RecordSecurityFiltering? SecurityFiltering { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }

	[Parameter()]
	public bool? Temporary { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeRecordRefParameter")]
[OutputType(typeof(RecordRefParameter))]
[Alias("RecordRefParameter")]
public class AddCBreezeRecordRefParameter : NewNamedItemCmdlet<RecordRefParameter, PSObject>
{
	protected override RecordRefParameter CreateItem()
	{
		var recordRefParameter = new RecordRefParameter(Name, Var, ID);
		recordRefParameter.Dimensions = Dimensions;
		recordRefParameter.SecurityFiltering = SecurityFiltering; 		return recordRefParameter;
	}

	protected override void AddItemToInputObject(RecordRefParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter()]
	public RecordSecurityFiltering? SecurityFiltering { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeReportParameter")]
[OutputType(typeof(ReportParameter))]
[Alias("ReportParameter")]
public class AddCBreezeReportParameter : NewNamedItemCmdlet<ReportParameter, PSObject>
{
	protected override ReportParameter CreateItem()
	{
		var reportParameter = new ReportParameter(Name, SubType, Var, ID);
		reportParameter.Dimensions = Dimensions;
		return reportParameter;
	}

	protected override void AddItemToInputObject(ReportParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTestPageParameter")]
[OutputType(typeof(TestPageParameter))]
[Alias("TestPageParameter")]
public class AddCBreezeTestPageParameter : NewNamedItemCmdlet<TestPageParameter, PSObject>
{
	protected override TestPageParameter CreateItem()
	{
		var testPageParameter = new TestPageParameter(Name, SubType, Var, ID);
		testPageParameter.Dimensions = Dimensions;
		return testPageParameter;
	}

	protected override void AddItemToInputObject(TestPageParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTestRequestPageParameter")]
[OutputType(typeof(TestRequestPageParameter))]
[Alias("TestRequestPageParameter")]
public class AddCBreezeTestRequestPageParameter : NewNamedItemCmdlet<TestRequestPageParameter, PSObject>
{
	protected override TestRequestPageParameter CreateItem()
	{
		var testRequestPageParameter = new TestRequestPageParameter(Name, SubType, Var, ID);
		testRequestPageParameter.Dimensions = Dimensions;
		return testRequestPageParameter;
	}

	protected override void AddItemToInputObject(TestRequestPageParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTextEncodingParameter")]
[OutputType(typeof(TextEncodingParameter))]
[Alias("TextEncodingParameter")]
public class AddCBreezeTextEncodingParameter : NewNamedItemCmdlet<TextEncodingParameter, PSObject>
{
	protected override TextEncodingParameter CreateItem()
	{
		var textEncodingParameter = new TextEncodingParameter(Name, Var, ID);
		textEncodingParameter.Dimensions = Dimensions;
		return textEncodingParameter;
	}

	protected override void AddItemToInputObject(TextEncodingParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTextParameter")]
[OutputType(typeof(TextParameter))]
[Alias("TextParameter")]
public class AddCBreezeTextParameter : NewNamedItemCmdlet<TextParameter, PSObject>
{
	protected override TextParameter CreateItem()
	{
		var textParameter = new TextParameter(Name, Var, ID, DataLength);
		textParameter.Dimensions = Dimensions;
		return textParameter;
	}

	protected override void AddItemToInputObject(TextParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}

	[Parameter(Mandatory=false)]
	[ValidateRange(1, int.MaxValue)]
	public int DataLength { get; set; }

	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTimeParameter")]
[OutputType(typeof(TimeParameter))]
[Alias("TimeParameter")]
public class AddCBreezeTimeParameter : NewNamedItemCmdlet<TimeParameter, PSObject>
{
	protected override TimeParameter CreateItem()
	{
		var timeParameter = new TimeParameter(Name, Var, ID);
		timeParameter.Dimensions = Dimensions;
		return timeParameter;
	}

	protected override void AddItemToInputObject(TimeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeTransactionTypeParameter")]
[OutputType(typeof(TransactionTypeParameter))]
[Alias("TransactionTypeParameter")]
public class AddCBreezeTransactionTypeParameter : NewNamedItemCmdlet<TransactionTypeParameter, PSObject>
{
	protected override TransactionTypeParameter CreateItem()
	{
		var transactionTypeParameter = new TransactionTypeParameter(Name, Var, ID);
		transactionTypeParameter.Dimensions = Dimensions;
		return transactionTypeParameter;
	}

	protected override void AddItemToInputObject(TransactionTypeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeVariantParameter")]
[OutputType(typeof(VariantParameter))]
[Alias("VariantParameter")]
public class AddCBreezeVariantParameter : NewNamedItemCmdlet<VariantParameter, PSObject>
{
	protected override VariantParameter CreateItem()
	{
		var variantParameter = new VariantParameter(Name, Var, ID);
		variantParameter.Dimensions = Dimensions;
		return variantParameter;
	}

	protected override void AddItemToInputObject(VariantParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.Add, "CBreezeXmlPortParameter")]
[OutputType(typeof(XmlPortParameter))]
[Alias("XmlPortParameter")]
public class AddCBreezeXmlPortParameter : NewNamedItemCmdlet<XmlPortParameter, PSObject>
{
	protected override XmlPortParameter CreateItem()
	{
		var xmlPortParameter = new XmlPortParameter(Name, SubType, Var, ID);
		xmlPortParameter.Dimensions = Dimensions;
		return xmlPortParameter;
	}

	protected override void AddItemToInputObject(XmlPortParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}


	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int SubType { get; set; }
}

}