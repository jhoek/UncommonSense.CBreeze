using System;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation 
{
	[Cmdlet(VerbsCommon.New, "CBreezeActionVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(ActionVariable))]
	[Alias("ActionVariable")]
	public class NewBreezeActionVariable : NewNamedItemCmdlet<ActionVariable, int, PSObject>
	{
		protected override ActionVariable CreateItem()
		{
			var actionVariable = new ActionVariable(ID, Name);
			actionVariable.Dimensions = Dimensions;
			return actionVariable;
		}

		protected override void AddItemToInputObject(ActionVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeAutomationVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(AutomationVariable))]
	[Alias("AutomationVariable")]
	public class NewBreezeAutomationVariable : NewNamedItemCmdlet<AutomationVariable, int, PSObject>
	{
		protected override AutomationVariable CreateItem()
		{
			var automationVariable = new AutomationVariable(ID, Name, SubType);
			automationVariable.Dimensions = Dimensions;
			automationVariable.WithEvents = WithEvents;
			return automationVariable;
		}

		protected override void AddItemToInputObject(AutomationVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public String SubType { get; set; }

		[Parameter()]
		public Nullable<Boolean> WithEvents { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeBigIntegerVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(BigIntegerVariable))]
	[Alias("BigIntegerVariable")]
	public class NewBreezeBigIntegerVariable : NewNamedItemCmdlet<BigIntegerVariable, int, PSObject>
	{
		protected override BigIntegerVariable CreateItem()
		{
			var bigIntegerVariable = new BigIntegerVariable(ID, Name);
			bigIntegerVariable.Dimensions = Dimensions;
			return bigIntegerVariable;
		}

		protected override void AddItemToInputObject(BigIntegerVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeBigTextVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(BigTextVariable))]
	[Alias("BigTextVariable")]
	public class NewBreezeBigTextVariable : NewNamedItemCmdlet<BigTextVariable, int, PSObject>
	{
		protected override BigTextVariable CreateItem()
		{
			var bigTextVariable = new BigTextVariable(ID, Name);
			bigTextVariable.Dimensions = Dimensions;
			return bigTextVariable;
		}

		protected override void AddItemToInputObject(BigTextVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeBinaryVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(BinaryVariable))]
	[Alias("BinaryVariable")]
	public class NewBreezeBinaryVariable : NewNamedItemCmdlet<BinaryVariable, int, PSObject>
	{
		protected override BinaryVariable CreateItem()
		{
			var binaryVariable = new BinaryVariable(ID, Name, DataLength);
			binaryVariable.Dimensions = Dimensions;
			return binaryVariable;
		}

		protected override void AddItemToInputObject(BinaryVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 DataLength { get; set; }

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeBooleanVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(BooleanVariable))]
	[Alias("BooleanVariable")]
	public class NewBreezeBooleanVariable : NewNamedItemCmdlet<BooleanVariable, int, PSObject>
	{
		protected override BooleanVariable CreateItem()
		{
			var booleanVariable = new BooleanVariable(ID, Name);
			booleanVariable.Dimensions = Dimensions;
			booleanVariable.IncludeInDataset = IncludeInDataset;
			return booleanVariable;
		}

		protected override void AddItemToInputObject(BooleanVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<Boolean> IncludeInDataset { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeByteVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(ByteVariable))]
	[Alias("ByteVariable")]
	public class NewBreezeByteVariable : NewNamedItemCmdlet<ByteVariable, int, PSObject>
	{
		protected override ByteVariable CreateItem()
		{
			var byteVariable = new ByteVariable(ID, Name);
			byteVariable.Dimensions = Dimensions;
			return byteVariable;
		}

		protected override void AddItemToInputObject(ByteVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeCharVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(CharVariable))]
	[Alias("CharVariable")]
	public class NewBreezeCharVariable : NewNamedItemCmdlet<CharVariable, int, PSObject>
	{
		protected override CharVariable CreateItem()
		{
			var charVariable = new CharVariable(ID, Name);
			charVariable.Dimensions = Dimensions;
			return charVariable;
		}

		protected override void AddItemToInputObject(CharVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeFilterPageBuilderVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(FilterPageBuilderVariable))]
	[Alias("FilterPageBuilderVariable")]
	public class NewBreezeFilterPageBuilderVariable : NewNamedItemCmdlet<FilterPageBuilderVariable, int, PSObject>
	{
		protected override FilterPageBuilderVariable CreateItem()
		{
			var filterPageBuilderVariable = new FilterPageBuilderVariable(ID, Name);
			filterPageBuilderVariable.Dimensions = Dimensions;
			return filterPageBuilderVariable;
		}

		protected override void AddItemToInputObject(FilterPageBuilderVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeCodeunitVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(CodeunitVariable))]
	[Alias("CodeunitVariable")]
	public class NewBreezeCodeunitVariable : NewNamedItemCmdlet<CodeunitVariable, int, PSObject>
	{
		protected override CodeunitVariable CreateItem()
		{
			var codeunitVariable = new CodeunitVariable(ID, Name, SubType);
			codeunitVariable.Dimensions = Dimensions;
			return codeunitVariable;
		}

		protected override void AddItemToInputObject(CodeunitVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeCodeVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(CodeVariable))]
	[Alias("CodeVariable")]
	public class NewBreezeCodeVariable : NewNamedItemCmdlet<CodeVariable, int, PSObject>
	{
		protected override CodeVariable CreateItem()
		{
			var codeVariable = new CodeVariable(ID, Name, DataLength);
			codeVariable.Dimensions = Dimensions;
			codeVariable.IncludeInDataset = IncludeInDataset;
			return codeVariable;
		}

		protected override void AddItemToInputObject(CodeVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Nullable<Int32> DataLength { get; set; }

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<Boolean> IncludeInDataset { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDateFormulaVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DateFormulaVariable))]
	[Alias("DateFormulaVariable")]
	public class NewBreezeDateFormulaVariable : NewNamedItemCmdlet<DateFormulaVariable, int, PSObject>
	{
		protected override DateFormulaVariable CreateItem()
		{
			var dateFormulaVariable = new DateFormulaVariable(ID, Name);
			dateFormulaVariable.Dimensions = Dimensions;
			return dateFormulaVariable;
		}

		protected override void AddItemToInputObject(DateFormulaVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDateTimeVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DateTimeVariable))]
	[Alias("DateTimeVariable")]
	public class NewBreezeDateTimeVariable : NewNamedItemCmdlet<DateTimeVariable, int, PSObject>
	{
		protected override DateTimeVariable CreateItem()
		{
			var dateTimeVariable = new DateTimeVariable(ID, Name);
			dateTimeVariable.Dimensions = Dimensions;
			return dateTimeVariable;
		}

		protected override void AddItemToInputObject(DateTimeVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDateVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DateVariable))]
	[Alias("DateVariable")]
	public class NewBreezeDateVariable : NewNamedItemCmdlet<DateVariable, int, PSObject>
	{
		protected override DateVariable CreateItem()
		{
			var dateVariable = new DateVariable(ID, Name);
			dateVariable.Dimensions = Dimensions;
			return dateVariable;
		}

		protected override void AddItemToInputObject(DateVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDecimalVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DecimalVariable))]
	[Alias("DecimalVariable")]
	public class NewBreezeDecimalVariable : NewNamedItemCmdlet<DecimalVariable, int, PSObject>
	{
		protected override DecimalVariable CreateItem()
		{
			var decimalVariable = new DecimalVariable(ID, Name);
			decimalVariable.Dimensions = Dimensions;
			return decimalVariable;
		}

		protected override void AddItemToInputObject(DecimalVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDialogVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DialogVariable))]
	[Alias("DialogVariable")]
	public class NewBreezeDialogVariable : NewNamedItemCmdlet<DialogVariable, int, PSObject>
	{
		protected override DialogVariable CreateItem()
		{
			var dialogVariable = new DialogVariable(ID, Name);
			dialogVariable.Dimensions = Dimensions;
			return dialogVariable;
		}

		protected override void AddItemToInputObject(DialogVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDotNetVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DotNetVariable))]
	[Alias("DotNetVariable")]
	public class NewBreezeDotNetVariable : NewNamedItemCmdlet<DotNetVariable, int, PSObject>
	{
		protected override DotNetVariable CreateItem()
		{
			var dotNetVariable = new DotNetVariable(ID, Name, SubType);
			dotNetVariable.Dimensions = Dimensions;
			dotNetVariable.RunOnClient = RunOnClient;
			dotNetVariable.WithEvents = WithEvents;
			return dotNetVariable;
		}

		protected override void AddItemToInputObject(DotNetVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<Boolean> RunOnClient { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public String SubType { get; set; }

		[Parameter()]
		public Nullable<Boolean> WithEvents { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeDurationVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DurationVariable))]
	[Alias("DurationVariable")]
	public class NewBreezeDurationVariable : NewNamedItemCmdlet<DurationVariable, int, PSObject>
	{
		protected override DurationVariable CreateItem()
		{
			var durationVariable = new DurationVariable(ID, Name);
			durationVariable.Dimensions = Dimensions;
			return durationVariable;
		}

		protected override void AddItemToInputObject(DurationVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeExecutionModeVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(ExecutionModeVariable))]
	[Alias("ExecutionModeVariable")]
	public class NewBreezeExecutionModeVariable : NewNamedItemCmdlet<ExecutionModeVariable, int, PSObject>
	{
		protected override ExecutionModeVariable CreateItem()
		{
			var executionModeVariable = new ExecutionModeVariable(ID, Name);
			executionModeVariable.Dimensions = Dimensions;
			return executionModeVariable;
		}

		protected override void AddItemToInputObject(ExecutionModeVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeFieldRefVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(FieldRefVariable))]
	[Alias("FieldRefVariable")]
	public class NewBreezeFieldRefVariable : NewNamedItemCmdlet<FieldRefVariable, int, PSObject>
	{
		protected override FieldRefVariable CreateItem()
		{
			var fieldRefVariable = new FieldRefVariable(ID, Name);
			fieldRefVariable.Dimensions = Dimensions;
			return fieldRefVariable;
		}

		protected override void AddItemToInputObject(FieldRefVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeFileVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(FileVariable))]
	[Alias("FileVariable")]
	public class NewBreezeFileVariable : NewNamedItemCmdlet<FileVariable, int, PSObject>
	{
		protected override FileVariable CreateItem()
		{
			var fileVariable = new FileVariable(ID, Name);
			fileVariable.Dimensions = Dimensions;
			return fileVariable;
		}

		protected override void AddItemToInputObject(FileVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeReportFormatVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(ReportFormatVariable))]
	[Alias("ReportFormatVariable")]
	public class NewBreezeReportFormatVariable : NewNamedItemCmdlet<ReportFormatVariable, int, PSObject>
	{
		protected override ReportFormatVariable CreateItem()
		{
			var reportFormatVariable = new ReportFormatVariable(ID, Name);
			reportFormatVariable.Dimensions = Dimensions;
			return reportFormatVariable;
		}

		protected override void AddItemToInputObject(ReportFormatVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTableConnectionTypeVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TableConnectionTypeVariable))]
	[Alias("TableConnectionTypeVariable")]
	public class NewBreezeTableConnectionTypeVariable : NewNamedItemCmdlet<TableConnectionTypeVariable, int, PSObject>
	{
		protected override TableConnectionTypeVariable CreateItem()
		{
			var tableConnectionTypeVariable = new TableConnectionTypeVariable(ID, Name);
			tableConnectionTypeVariable.Dimensions = Dimensions;
			return tableConnectionTypeVariable;
		}

		protected override void AddItemToInputObject(TableConnectionTypeVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeGuidVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(GuidVariable))]
	[Alias("GuidVariable")]
	public class NewBreezeGuidVariable : NewNamedItemCmdlet<GuidVariable, int, PSObject>
	{
		protected override GuidVariable CreateItem()
		{
			var guidVariable = new GuidVariable(ID, Name);
			guidVariable.Dimensions = Dimensions;
			return guidVariable;
		}

		protected override void AddItemToInputObject(GuidVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeInStreamVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(InStreamVariable))]
	[Alias("InStreamVariable")]
	public class NewBreezeInStreamVariable : NewNamedItemCmdlet<InStreamVariable, int, PSObject>
	{
		protected override InStreamVariable CreateItem()
		{
			var inStreamVariable = new InStreamVariable(ID, Name);
			inStreamVariable.Dimensions = Dimensions;
			return inStreamVariable;
		}

		protected override void AddItemToInputObject(InStreamVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeIntegerVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(IntegerVariable))]
	[Alias("IntegerVariable")]
	public class NewBreezeIntegerVariable : NewNamedItemCmdlet<IntegerVariable, int, PSObject>
	{
		protected override IntegerVariable CreateItem()
		{
			var integerVariable = new IntegerVariable(ID, Name);
			integerVariable.Dimensions = Dimensions;
			integerVariable.IncludeInDataset = IncludeInDataset;
			return integerVariable;
		}

		protected override void AddItemToInputObject(IntegerVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<Boolean> IncludeInDataset { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeKeyRefVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(KeyRefVariable))]
	[Alias("KeyRefVariable")]
	public class NewBreezeKeyRefVariable : NewNamedItemCmdlet<KeyRefVariable, int, PSObject>
	{
		protected override KeyRefVariable CreateItem()
		{
			var keyRefVariable = new KeyRefVariable(ID, Name);
			keyRefVariable.Dimensions = Dimensions;
			return keyRefVariable;
		}

		protected override void AddItemToInputObject(KeyRefVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeOcxVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(OcxVariable))]
	[Alias("OcxVariable")]
	public class NewBreezeOcxVariable : NewNamedItemCmdlet<OcxVariable, int, PSObject>
	{
		protected override OcxVariable CreateItem()
		{
			var ocxVariable = new OcxVariable(ID, Name, SubType);
			ocxVariable.Dimensions = Dimensions;
			return ocxVariable;
		}

		protected override void AddItemToInputObject(OcxVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public String SubType { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeOptionVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(OptionVariable))]
	[Alias("OptionVariable")]
	public class NewBreezeOptionVariable : NewNamedItemCmdlet<OptionVariable, int, PSObject>
	{
		protected override OptionVariable CreateItem()
		{
			var optionVariable = new OptionVariable(ID, Name);
			optionVariable.Dimensions = Dimensions;
			optionVariable.OptionString = OptionString;
			return optionVariable;
		}

		protected override void AddItemToInputObject(OptionVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Position=3, ParameterSetName="AddWithID")]
		[Parameter(Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Position=3, ParameterSetName="NewWithID")]
		[Parameter(Position=2, ParameterSetName="NewWithoutID")]
		public String OptionString { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeOutStreamVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(OutStreamVariable))]
	[Alias("OutStreamVariable")]
	public class NewBreezeOutStreamVariable : NewNamedItemCmdlet<OutStreamVariable, int, PSObject>
	{
		protected override OutStreamVariable CreateItem()
		{
			var outStreamVariable = new OutStreamVariable(ID, Name);
			outStreamVariable.Dimensions = Dimensions;
			return outStreamVariable;
		}

		protected override void AddItemToInputObject(OutStreamVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezePageVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(PageVariable))]
	[Alias("PageVariable")]
	public class NewBreezePageVariable : NewNamedItemCmdlet<PageVariable, int, PSObject>
	{
		protected override PageVariable CreateItem()
		{
			var pageVariable = new PageVariable(ID, Name, SubType);
			pageVariable.Dimensions = Dimensions;
			return pageVariable;
		}

		protected override void AddItemToInputObject(PageVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeQueryVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(QueryVariable))]
	[Alias("QueryVariable")]
	public class NewBreezeQueryVariable : NewNamedItemCmdlet<QueryVariable, int, PSObject>
	{
		protected override QueryVariable CreateItem()
		{
			var queryVariable = new QueryVariable(ID, Name, SubType);
			queryVariable.Dimensions = Dimensions;
			queryVariable.SecurityFiltering = SecurityFiltering;
			return queryVariable;
		}

		protected override void AddItemToInputObject(QueryVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<QuerySecurityFiltering> SecurityFiltering { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeRecordIDVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(RecordIDVariable))]
	[Alias("RecordIDVariable")]
	public class NewBreezeRecordIDVariable : NewNamedItemCmdlet<RecordIDVariable, int, PSObject>
	{
		protected override RecordIDVariable CreateItem()
		{
			var recordIDVariable = new RecordIDVariable(ID, Name);
			recordIDVariable.Dimensions = Dimensions;
			return recordIDVariable;
		}

		protected override void AddItemToInputObject(RecordIDVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeRecordRefVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(RecordRefVariable))]
	[Alias("RecordRefVariable")]
	public class NewBreezeRecordRefVariable : NewNamedItemCmdlet<RecordRefVariable, int, PSObject>
	{
		protected override RecordRefVariable CreateItem()
		{
			var recordRefVariable = new RecordRefVariable(ID, Name);
			recordRefVariable.Dimensions = Dimensions;
			recordRefVariable.SecurityFiltering = SecurityFiltering;
			return recordRefVariable;
		}

		protected override void AddItemToInputObject(RecordRefVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<RecordSecurityFiltering> SecurityFiltering { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeRecordVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(RecordVariable))]
	[Alias("RecordVariable")]
	public class NewBreezeRecordVariable : NewNamedItemCmdlet<RecordVariable, int, PSObject>
	{
		protected override RecordVariable CreateItem()
		{
			var recordVariable = new RecordVariable(ID, Name, SubType);
			recordVariable.Dimensions = Dimensions;
			recordVariable.SecurityFiltering = SecurityFiltering;
			recordVariable.Temporary = Temporary;
			return recordVariable;
		}

		protected override void AddItemToInputObject(RecordVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<RecordSecurityFiltering> SecurityFiltering { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

		[Parameter()]
		public Nullable<Boolean> Temporary { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeReportVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(ReportVariable))]
	[Alias("ReportVariable")]
	public class NewBreezeReportVariable : NewNamedItemCmdlet<ReportVariable, int, PSObject>
	{
		protected override ReportVariable CreateItem()
		{
			var reportVariable = new ReportVariable(ID, Name, SubType);
			reportVariable.Dimensions = Dimensions;
			return reportVariable;
		}

		protected override void AddItemToInputObject(ReportVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTestPageVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TestPageVariable))]
	[Alias("TestPageVariable")]
	public class NewBreezeTestPageVariable : NewNamedItemCmdlet<TestPageVariable, int, PSObject>
	{
		protected override TestPageVariable CreateItem()
		{
			var testPageVariable = new TestPageVariable(ID, Name, SubType);
			testPageVariable.Dimensions = Dimensions;
			return testPageVariable;
		}

		protected override void AddItemToInputObject(TestPageVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTextConstant", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TextConstant))]
	[Alias("TextConstant")]
	public class NewBreezeTextConstant : NewNamedItemCmdlet<TextConstant, int, PSObject>
	{
		protected override TextConstant CreateItem()
		{
			var textConstant = new TextConstant(ID, Name);
			return textConstant;
		}

		protected override void AddItemToInputObject(TextConstant item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTextEncodingVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TextEncodingVariable))]
	[Alias("TextEncodingVariable")]
	public class NewBreezeTextEncodingVariable : NewNamedItemCmdlet<TextEncodingVariable, int, PSObject>
	{
		protected override TextEncodingVariable CreateItem()
		{
			var textEncodingVariable = new TextEncodingVariable(ID, Name);
			textEncodingVariable.Dimensions = Dimensions;
			return textEncodingVariable;
		}

		protected override void AddItemToInputObject(TextEncodingVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTextVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TextVariable))]
	[Alias("TextVariable")]
	public class NewBreezeTextVariable : NewNamedItemCmdlet<TextVariable, int, PSObject>
	{
		protected override TextVariable CreateItem()
		{
			var textVariable = new TextVariable(ID, Name, DataLength);
			textVariable.Dimensions = Dimensions;
			textVariable.IncludeInDataset = IncludeInDataset;
			return textVariable;
		}

		protected override void AddItemToInputObject(TextVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter(Position=3, ParameterSetName="AddWithID")]
		[Parameter(Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Position=3, ParameterSetName="NewWithID")]
		[Parameter(Position=2, ParameterSetName="NewWithoutID")]
		public Nullable<Int32> DataLength { get; set; }

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter()]
		public Nullable<Boolean> IncludeInDataset { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTimeVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TimeVariable))]
	[Alias("TimeVariable")]
	public class NewBreezeTimeVariable : NewNamedItemCmdlet<TimeVariable, int, PSObject>
	{
		protected override TimeVariable CreateItem()
		{
			var timeVariable = new TimeVariable(ID, Name);
			timeVariable.Dimensions = Dimensions;
			return timeVariable;
		}

		protected override void AddItemToInputObject(TimeVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeTransactionTypeVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(TransactionTypeVariable))]
	[Alias("TransactionTypeVariable")]
	public class NewBreezeTransactionTypeVariable : NewNamedItemCmdlet<TransactionTypeVariable, int, PSObject>
	{
		protected override TransactionTypeVariable CreateItem()
		{
			var transactionTypeVariable = new TransactionTypeVariable(ID, Name);
			transactionTypeVariable.Dimensions = Dimensions;
			return transactionTypeVariable;
		}

		protected override void AddItemToInputObject(TransactionTypeVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeVariantVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(VariantVariable))]
	[Alias("VariantVariable")]
	public class NewBreezeVariantVariable : NewNamedItemCmdlet<VariantVariable, int, PSObject>
	{
		protected override VariantVariable CreateItem()
		{
			var variantVariable = new VariantVariable(ID, Name);
			variantVariable.Dimensions = Dimensions;
			return variantVariable;
		}

		protected override void AddItemToInputObject(VariantVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "CBreezeXmlPortVariable", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(XmlPortVariable))]
	[Alias("XmlPortVariable")]
	public class NewBreezeXmlPortVariable : NewNamedItemCmdlet<XmlPortVariable, int, PSObject>
	{
		protected override XmlPortVariable CreateItem()
		{
			var xmlPortVariable = new XmlPortVariable(ID, Name, SubType);
			xmlPortVariable.Dimensions = Dimensions;
			return xmlPortVariable;
		}

		protected override void AddItemToInputObject(XmlPortVariable item, PSObject inputObject)
		{
			inputObject.GetVariables().Add(item);
		}

		[Parameter()]
		public String Dimensions { get; set; }

		[Parameter(Mandatory=true, Position=3, ParameterSetName="AddWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="AddWithoutID")]
		[Parameter(Mandatory=true, Position=3, ParameterSetName="NewWithID")]
		[Parameter(Mandatory=true, Position=2, ParameterSetName="NewWithoutID")]
		public Int32 SubType { get; set; }

	}

}

