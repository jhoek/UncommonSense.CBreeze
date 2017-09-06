using System;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation 
{
[Cmdlet(VerbsCommon.New, "CBreezeActionParameter")]
[OutputType(typeof(ActionParameter))]
[Alias("ActionParameter")]
public class NewCBreezeActionParameter : NewItemWithIDAndNameCmdlet<ActionParameter, int, PSObject>
{
protected override IEnumerable<ActionParameter> CreateItems()
	{
		var actionParameter = new ActionParameter(Name, Var, ID);
		actionParameter.Dimensions = Dimensions;
		yield return actionParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeAutomationParameter")]
[OutputType(typeof(AutomationParameter))]
[Alias("AutomationParameter")]
public class NewCBreezeAutomationParameter : NewItemWithIDAndNameCmdlet<AutomationParameter, int, PSObject>
{
protected override IEnumerable<AutomationParameter> CreateItems()
	{
		var automationParameter = new AutomationParameter(Name, SubType, Var, ID);
		automationParameter.Dimensions = Dimensions;
		yield return automationParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeBigIntegerParameter")]
[OutputType(typeof(BigIntegerParameter))]
[Alias("BigIntegerParameter")]
public class NewCBreezeBigIntegerParameter : NewItemWithIDAndNameCmdlet<BigIntegerParameter, int, PSObject>
{
protected override IEnumerable<BigIntegerParameter> CreateItems()
	{
		var bigIntegerParameter = new BigIntegerParameter(Name, Var, ID);
		bigIntegerParameter.Dimensions = Dimensions;
		yield return bigIntegerParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeBigTextParameter")]
[OutputType(typeof(BigTextParameter))]
[Alias("BigTextParameter")]
public class NewCBreezeBigTextParameter : NewItemWithIDAndNameCmdlet<BigTextParameter, int, PSObject>
{
protected override IEnumerable<BigTextParameter> CreateItems()
	{
		var bigTextParameter = new BigTextParameter(Name, Var, ID);
		bigTextParameter.Dimensions = Dimensions;
		yield return bigTextParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeBinaryParameter")]
[OutputType(typeof(BinaryParameter))]
[Alias("BinaryParameter")]
public class NewCBreezeBinaryParameter : NewItemWithIDAndNameCmdlet<BinaryParameter, int, PSObject>
{
protected override IEnumerable<BinaryParameter> CreateItems()
	{
		var binaryParameter = new BinaryParameter(Name, Var, ID, DataLength);
		binaryParameter.Dimensions = Dimensions;
		yield return binaryParameter;
	}

	protected override void AddItemToInputObject(BinaryParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}

	[Parameter(Mandatory=true)]
	[ValidateRange(1, int.MaxValue)]
	public int? DataLength { get; set; }

	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.New, "CBreezeBooleanParameter")]
[OutputType(typeof(BooleanParameter))]
[Alias("BooleanParameter")]
public class NewCBreezeBooleanParameter : NewItemWithIDAndNameCmdlet<BooleanParameter, int, PSObject>
{
protected override IEnumerable<BooleanParameter> CreateItems()
	{
		var booleanParameter = new BooleanParameter(Name, Var, ID);
		booleanParameter.Dimensions = Dimensions;
		yield return booleanParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeByteParameter")]
[OutputType(typeof(ByteParameter))]
[Alias("ByteParameter")]
public class NewCBreezeByteParameter : NewItemWithIDAndNameCmdlet<ByteParameter, int, PSObject>
{
protected override IEnumerable<ByteParameter> CreateItems()
	{
		var byteParameter = new ByteParameter(Name, Var, ID);
		byteParameter.Dimensions = Dimensions;
		yield return byteParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeCharParameter")]
[OutputType(typeof(CharParameter))]
[Alias("CharParameter")]
public class NewCBreezeCharParameter : NewItemWithIDAndNameCmdlet<CharParameter, int, PSObject>
{
protected override IEnumerable<CharParameter> CreateItems()
	{
		var charParameter = new CharParameter(Name, Var, ID);
		charParameter.Dimensions = Dimensions;
		yield return charParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeFilterPageBuilderParameter")]
[OutputType(typeof(FilterPageBuilderParameter))]
[Alias("FilterPageBuilderParameter")]
public class NewCBreezeFilterPageBuilderParameter : NewItemWithIDAndNameCmdlet<FilterPageBuilderParameter, int, PSObject>
{
protected override IEnumerable<FilterPageBuilderParameter> CreateItems()
	{
		var filterPageBuilderParameter = new FilterPageBuilderParameter(Name, Var, ID);
		filterPageBuilderParameter.Dimensions = Dimensions;
		yield return filterPageBuilderParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeCodeParameter")]
[OutputType(typeof(CodeParameter))]
[Alias("CodeParameter")]
public class NewCBreezeCodeParameter : NewItemWithIDAndNameCmdlet<CodeParameter, int, PSObject>
{
protected override IEnumerable<CodeParameter> CreateItems()
	{
		var codeParameter = new CodeParameter(Name, Var, ID, DataLength);
		codeParameter.Dimensions = Dimensions;
		yield return codeParameter;
	}

	protected override void AddItemToInputObject(CodeParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}

	[Parameter(Mandatory=false)]
	[ValidateRange(1, int.MaxValue)]
	public int? DataLength { get; set; }

	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.New, "CBreezeCodeunitParameter")]
[OutputType(typeof(CodeunitParameter))]
[Alias("CodeunitParameter")]
public class NewCBreezeCodeunitParameter : NewItemWithIDAndNameCmdlet<CodeunitParameter, int, PSObject>
{
protected override IEnumerable<CodeunitParameter> CreateItems()
	{
		var codeunitParameter = new CodeunitParameter(Name, SubType, Var, ID);
		codeunitParameter.Dimensions = Dimensions;
		yield return codeunitParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDateFormulaParameter")]
[OutputType(typeof(DateFormulaParameter))]
[Alias("DateFormulaParameter")]
public class NewCBreezeDateFormulaParameter : NewItemWithIDAndNameCmdlet<DateFormulaParameter, int, PSObject>
{
protected override IEnumerable<DateFormulaParameter> CreateItems()
	{
		var dateFormulaParameter = new DateFormulaParameter(Name, Var, ID);
		dateFormulaParameter.Dimensions = Dimensions;
		yield return dateFormulaParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDateParameter")]
[OutputType(typeof(DateParameter))]
[Alias("DateParameter")]
public class NewCBreezeDateParameter : NewItemWithIDAndNameCmdlet<DateParameter, int, PSObject>
{
protected override IEnumerable<DateParameter> CreateItems()
	{
		var dateParameter = new DateParameter(Name, Var, ID);
		dateParameter.Dimensions = Dimensions;
		yield return dateParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDateTimeParameter")]
[OutputType(typeof(DateTimeParameter))]
[Alias("DateTimeParameter")]
public class NewCBreezeDateTimeParameter : NewItemWithIDAndNameCmdlet<DateTimeParameter, int, PSObject>
{
protected override IEnumerable<DateTimeParameter> CreateItems()
	{
		var dateTimeParameter = new DateTimeParameter(Name, Var, ID);
		dateTimeParameter.Dimensions = Dimensions;
		yield return dateTimeParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDecimalParameter")]
[OutputType(typeof(DecimalParameter))]
[Alias("DecimalParameter")]
public class NewCBreezeDecimalParameter : NewItemWithIDAndNameCmdlet<DecimalParameter, int, PSObject>
{
protected override IEnumerable<DecimalParameter> CreateItems()
	{
		var decimalParameter = new DecimalParameter(Name, Var, ID);
		decimalParameter.Dimensions = Dimensions;
		yield return decimalParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDialogParameter")]
[OutputType(typeof(DialogParameter))]
[Alias("DialogParameter")]
public class NewCBreezeDialogParameter : NewItemWithIDAndNameCmdlet<DialogParameter, int, PSObject>
{
protected override IEnumerable<DialogParameter> CreateItems()
	{
		var dialogParameter = new DialogParameter(Name, Var, ID);
		dialogParameter.Dimensions = Dimensions;
		yield return dialogParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDotNetParameter")]
[OutputType(typeof(DotNetParameter))]
[Alias("DotNetParameter")]
public class NewCBreezeDotNetParameter : NewItemWithIDAndNameCmdlet<DotNetParameter, int, PSObject>
{
protected override IEnumerable<DotNetParameter> CreateItems()
	{
		var dotNetParameter = new DotNetParameter(Name, SubType, Var, ID);
		dotNetParameter.Dimensions = Dimensions;
		dotNetParameter.RunOnClient = RunOnClient; 		dotNetParameter.SuppressDispose = SuppressDispose; 		yield return dotNetParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeDurationParameter")]
[OutputType(typeof(DurationParameter))]
[Alias("DurationParameter")]
public class NewCBreezeDurationParameter : NewItemWithIDAndNameCmdlet<DurationParameter, int, PSObject>
{
protected override IEnumerable<DurationParameter> CreateItems()
	{
		var durationParameter = new DurationParameter(Name, Var, ID);
		durationParameter.Dimensions = Dimensions;
		yield return durationParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeExecutionModeParameter")]
[OutputType(typeof(ExecutionModeParameter))]
[Alias("ExecutionModeParameter")]
public class NewCBreezeExecutionModeParameter : NewItemWithIDAndNameCmdlet<ExecutionModeParameter, int, PSObject>
{
protected override IEnumerable<ExecutionModeParameter> CreateItems()
	{
		var executionModeParameter = new ExecutionModeParameter(Name, Var, ID);
		executionModeParameter.Dimensions = Dimensions;
		yield return executionModeParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeFieldRefParameter")]
[OutputType(typeof(FieldRefParameter))]
[Alias("FieldRefParameter")]
public class NewCBreezeFieldRefParameter : NewItemWithIDAndNameCmdlet<FieldRefParameter, int, PSObject>
{
protected override IEnumerable<FieldRefParameter> CreateItems()
	{
		var fieldRefParameter = new FieldRefParameter(Name, Var, ID);
		fieldRefParameter.Dimensions = Dimensions;
		yield return fieldRefParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeFileParameter")]
[OutputType(typeof(FileParameter))]
[Alias("FileParameter")]
public class NewCBreezeFileParameter : NewItemWithIDAndNameCmdlet<FileParameter, int, PSObject>
{
protected override IEnumerable<FileParameter> CreateItems()
	{
		var fileParameter = new FileParameter(Name, Var, ID);
		fileParameter.Dimensions = Dimensions;
		yield return fileParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeReportFormatParameter")]
[OutputType(typeof(ReportFormatParameter))]
[Alias("ReportFormatParameter")]
public class NewCBreezeReportFormatParameter : NewItemWithIDAndNameCmdlet<ReportFormatParameter, int, PSObject>
{
protected override IEnumerable<ReportFormatParameter> CreateItems()
	{
		var reportFormatParameter = new ReportFormatParameter(Name, Var, ID);
		reportFormatParameter.Dimensions = Dimensions;
		yield return reportFormatParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeTableConnectionTypeParameter")]
[OutputType(typeof(TableConnectionTypeParameter))]
[Alias("TableConnectionTypeParameter")]
public class NewCBreezeTableConnectionTypeParameter : NewItemWithIDAndNameCmdlet<TableConnectionTypeParameter, int, PSObject>
{
protected override IEnumerable<TableConnectionTypeParameter> CreateItems()
	{
		var tableConnectionTypeParameter = new TableConnectionTypeParameter(Name, Var, ID);
		tableConnectionTypeParameter.Dimensions = Dimensions;
		yield return tableConnectionTypeParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeGuidParameter")]
[OutputType(typeof(GuidParameter))]
[Alias("GuidParameter")]
public class NewCBreezeGuidParameter : NewItemWithIDAndNameCmdlet<GuidParameter, int, PSObject>
{
protected override IEnumerable<GuidParameter> CreateItems()
	{
		var guidParameter = new GuidParameter(Name, Var, ID);
		guidParameter.Dimensions = Dimensions;
		yield return guidParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeInStreamParameter")]
[OutputType(typeof(InStreamParameter))]
[Alias("InStreamParameter")]
public class NewCBreezeInStreamParameter : NewItemWithIDAndNameCmdlet<InStreamParameter, int, PSObject>
{
protected override IEnumerable<InStreamParameter> CreateItems()
	{
		var inStreamParameter = new InStreamParameter(Name, Var, ID);
		inStreamParameter.Dimensions = Dimensions;
		yield return inStreamParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeIntegerParameter")]
[OutputType(typeof(IntegerParameter))]
[Alias("IntegerParameter")]
public class NewCBreezeIntegerParameter : NewItemWithIDAndNameCmdlet<IntegerParameter, int, PSObject>
{
protected override IEnumerable<IntegerParameter> CreateItems()
	{
		var integerParameter = new IntegerParameter(Name, Var, ID);
		integerParameter.Dimensions = Dimensions;
		yield return integerParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeKeyRefParameter")]
[OutputType(typeof(KeyRefParameter))]
[Alias("KeyRefParameter")]
public class NewCBreezeKeyRefParameter : NewItemWithIDAndNameCmdlet<KeyRefParameter, int, PSObject>
{
protected override IEnumerable<KeyRefParameter> CreateItems()
	{
		var keyRefParameter = new KeyRefParameter(Name, Var, ID);
		keyRefParameter.Dimensions = Dimensions;
		yield return keyRefParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeOcxParameter")]
[OutputType(typeof(OcxParameter))]
[Alias("OcxParameter")]
public class NewCBreezeOcxParameter : NewItemWithIDAndNameCmdlet<OcxParameter, int, PSObject>
{
protected override IEnumerable<OcxParameter> CreateItems()
	{
		var ocxParameter = new OcxParameter(Name, SubType, Var, ID);
		ocxParameter.Dimensions = Dimensions;
		yield return ocxParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeOptionParameter")]
[OutputType(typeof(OptionParameter))]
[Alias("OptionParameter")]
public class NewCBreezeOptionParameter : NewItemWithIDAndNameCmdlet<OptionParameter, int, PSObject>
{
protected override IEnumerable<OptionParameter> CreateItems()
	{
		var optionParameter = new OptionParameter(Name, Var, ID);
		optionParameter.Dimensions = Dimensions;
		optionParameter.OptionString = OptionString; 		yield return optionParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeOutStreamParameter")]
[OutputType(typeof(OutStreamParameter))]
[Alias("OutStreamParameter")]
public class NewCBreezeOutStreamParameter : NewItemWithIDAndNameCmdlet<OutStreamParameter, int, PSObject>
{
protected override IEnumerable<OutStreamParameter> CreateItems()
	{
		var outStreamParameter = new OutStreamParameter(Name, Var, ID);
		outStreamParameter.Dimensions = Dimensions;
		yield return outStreamParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezePageParameter")]
[OutputType(typeof(PageParameter))]
[Alias("PageParameter")]
public class NewCBreezePageParameter : NewItemWithIDAndNameCmdlet<PageParameter, int, PSObject>
{
protected override IEnumerable<PageParameter> CreateItems()
	{
		var pageParameter = new PageParameter(Name, SubType, Var, ID);
		pageParameter.Dimensions = Dimensions;
		yield return pageParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeQueryParameter")]
[OutputType(typeof(QueryParameter))]
[Alias("QueryParameter")]
public class NewCBreezeQueryParameter : NewItemWithIDAndNameCmdlet<QueryParameter, int, PSObject>
{
protected override IEnumerable<QueryParameter> CreateItems()
	{
		var queryParameter = new QueryParameter(Name, SubType, Var, ID);
		queryParameter.Dimensions = Dimensions;
		queryParameter.SecurityFiltering = SecurityFiltering; 		yield return queryParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeRecordIDParameter")]
[OutputType(typeof(RecordIDParameter))]
[Alias("RecordIDParameter")]
public class NewCBreezeRecordIDParameter : NewItemWithIDAndNameCmdlet<RecordIDParameter, int, PSObject>
{
protected override IEnumerable<RecordIDParameter> CreateItems()
	{
		var recordIDParameter = new RecordIDParameter(Name, Var, ID);
		recordIDParameter.Dimensions = Dimensions;
		yield return recordIDParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeRecordParameter")]
[OutputType(typeof(RecordParameter))]
[Alias("RecordParameter")]
public class NewCBreezeRecordParameter : NewItemWithIDAndNameCmdlet<RecordParameter, int, PSObject>
{
protected override IEnumerable<RecordParameter> CreateItems()
	{
		var recordParameter = new RecordParameter(Name, SubType, Var, ID);
		recordParameter.Dimensions = Dimensions;
		recordParameter.SecurityFiltering = SecurityFiltering; 		recordParameter.Temporary = Temporary; 		yield return recordParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeRecordRefParameter")]
[OutputType(typeof(RecordRefParameter))]
[Alias("RecordRefParameter")]
public class NewCBreezeRecordRefParameter : NewItemWithIDAndNameCmdlet<RecordRefParameter, int, PSObject>
{
protected override IEnumerable<RecordRefParameter> CreateItems()
	{
		var recordRefParameter = new RecordRefParameter(Name, Var, ID);
		recordRefParameter.Dimensions = Dimensions;
		recordRefParameter.SecurityFiltering = SecurityFiltering; 		yield return recordRefParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeReportParameter")]
[OutputType(typeof(ReportParameter))]
[Alias("ReportParameter")]
public class NewCBreezeReportParameter : NewItemWithIDAndNameCmdlet<ReportParameter, int, PSObject>
{
protected override IEnumerable<ReportParameter> CreateItems()
	{
		var reportParameter = new ReportParameter(Name, SubType, Var, ID);
		reportParameter.Dimensions = Dimensions;
		yield return reportParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeTestPageParameter")]
[OutputType(typeof(TestPageParameter))]
[Alias("TestPageParameter")]
public class NewCBreezeTestPageParameter : NewItemWithIDAndNameCmdlet<TestPageParameter, int, PSObject>
{
protected override IEnumerable<TestPageParameter> CreateItems()
	{
		var testPageParameter = new TestPageParameter(Name, SubType, Var, ID);
		testPageParameter.Dimensions = Dimensions;
		yield return testPageParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeTestRequestPageParameter")]
[OutputType(typeof(TestRequestPageParameter))]
[Alias("TestRequestPageParameter")]
public class NewCBreezeTestRequestPageParameter : NewItemWithIDAndNameCmdlet<TestRequestPageParameter, int, PSObject>
{
protected override IEnumerable<TestRequestPageParameter> CreateItems()
	{
		var testRequestPageParameter = new TestRequestPageParameter(Name, SubType, Var, ID);
		testRequestPageParameter.Dimensions = Dimensions;
		yield return testRequestPageParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeTextEncodingParameter")]
[OutputType(typeof(TextEncodingParameter))]
[Alias("TextEncodingParameter")]
public class NewCBreezeTextEncodingParameter : NewItemWithIDAndNameCmdlet<TextEncodingParameter, int, PSObject>
{
protected override IEnumerable<TextEncodingParameter> CreateItems()
	{
		var textEncodingParameter = new TextEncodingParameter(Name, Var, ID);
		textEncodingParameter.Dimensions = Dimensions;
		yield return textEncodingParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeTextParameter")]
[OutputType(typeof(TextParameter))]
[Alias("TextParameter")]
public class NewCBreezeTextParameter : NewItemWithIDAndNameCmdlet<TextParameter, int, PSObject>
{
protected override IEnumerable<TextParameter> CreateItems()
	{
		var textParameter = new TextParameter(Name, Var, ID, DataLength);
		textParameter.Dimensions = Dimensions;
		yield return textParameter;
	}

	protected override void AddItemToInputObject(TextParameter item, PSObject inputObject)
	{
		inputObject.GetParameters().Add(item);	
	}

	[Parameter(Mandatory=false)]
	[ValidateRange(1, int.MaxValue)]
	public int? DataLength { get; set; }

	[Parameter()]
	public SwitchParameter Var { get; set; }

	[Parameter()]
	public string Dimensions { get; set; }
}

[Cmdlet(VerbsCommon.New, "CBreezeTimeParameter")]
[OutputType(typeof(TimeParameter))]
[Alias("TimeParameter")]
public class NewCBreezeTimeParameter : NewItemWithIDAndNameCmdlet<TimeParameter, int, PSObject>
{
protected override IEnumerable<TimeParameter> CreateItems()
	{
		var timeParameter = new TimeParameter(Name, Var, ID);
		timeParameter.Dimensions = Dimensions;
		yield return timeParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeTransactionTypeParameter")]
[OutputType(typeof(TransactionTypeParameter))]
[Alias("TransactionTypeParameter")]
public class NewCBreezeTransactionTypeParameter : NewItemWithIDAndNameCmdlet<TransactionTypeParameter, int, PSObject>
{
protected override IEnumerable<TransactionTypeParameter> CreateItems()
	{
		var transactionTypeParameter = new TransactionTypeParameter(Name, Var, ID);
		transactionTypeParameter.Dimensions = Dimensions;
		yield return transactionTypeParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeVariantParameter")]
[OutputType(typeof(VariantParameter))]
[Alias("VariantParameter")]
public class NewCBreezeVariantParameter : NewItemWithIDAndNameCmdlet<VariantParameter, int, PSObject>
{
protected override IEnumerable<VariantParameter> CreateItems()
	{
		var variantParameter = new VariantParameter(Name, Var, ID);
		variantParameter.Dimensions = Dimensions;
		yield return variantParameter;
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

[Cmdlet(VerbsCommon.New, "CBreezeXmlPortParameter")]
[OutputType(typeof(XmlPortParameter))]
[Alias("XmlPortParameter")]
public class NewCBreezeXmlPortParameter : NewItemWithIDAndNameCmdlet<XmlPortParameter, int, PSObject>
{
protected override IEnumerable<XmlPortParameter> CreateItems()
	{
		var xmlPortParameter = new XmlPortParameter(Name, SubType, Var, ID);
		xmlPortParameter.Dimensions = Dimensions;
		yield return xmlPortParameter;
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