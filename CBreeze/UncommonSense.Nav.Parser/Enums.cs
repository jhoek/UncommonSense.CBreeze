using System;

namespace UncommonSense.Nav.Parser
{
	public enum ObjectType
	{
		Table,
		Page,
		Report,
		Codeunit,
		Query,
		XmlPort,
		MenuSuite,
	}

	public enum SectionType
	{
		// General:
		ObjectProperties,
		Properties,
		// Table:
		Fields,
		Keys,
		FieldGroups,
		// Page:
		Controls,
		// Query:
		Elements,
        // XmlPort:
        Events,
        RequestPage,
        // Report:
        Dataset,
        Labels,
        RdlData,
        // Menusuite:
        MenuNodes,
		// General:
		Code
	}

	public enum FieldType
	{
		BigInteger,
		Binary,
		Blob,
		Boolean,
		Code,
		DateFormula,
		Date,
		DateTime,
		Decimal,
		Duration,
		Guid,
		Integer,
		Option,
		RecordID,
		TableFilter,
		Text,
		Time,
	}

	public enum PageControlType
	{
		Container,
		Group,
		Field,
		Part
	}

	public enum PageActionType
	{
		ActionContainer,
		ActionGroup,
		Action,
		Separator
	}

	public enum QueryElementType
	{
		DataItem,
		Filter,
		Column
	}

    public enum XmlPortNodeType
    {
        Element,
        Attribute
    }

    public enum XmlPortSourceType
    {
        Text,
        Table,
        Field
    }

    public enum ReportElementType
    {
        DataItem,
        Column
    }

    public enum MenuSuiteNodeType
    {
        Root,
        Menu,
        MenuGroup,
        MenuItem,
        Delta,
    }

	public enum ParameterType
	{
		Action,
		Automation,
		BigInteger,
		BigText,
		Binary,
		Boolean,
		Byte,
		Char,
		Code,
		Codeunit,
		DateFormula,
		Date,
		DateTime,
		Decimal,
		Dialog,
		DotNet,
		Duration,
		ExecutionMode,
		FieldRef,
		File,
		Guid,
		InStream,
		Integer,
		KeyRef,
		Ocx,
		Option,
		OutStream,
		Page,
		Query,
		RecordID,
		Record,
		RecordRef,
		Report,
		TestPage,
		TestRequestPage,
		Text,
		Time,
		TransactionType,
		Variant,
		XmlPort
	}

	public enum ReturnValueType
	{
		Boolean,
		Integer,
		Decimal,
		BigInteger,
		Char,
		Text,
		Code,
		Date,
		Time,
		Duration,
		DateTime,
		Binary,
		Guid,
		Byte,
		Option
	}

	public enum VariableType
	{
		Action,
		Automation,
		BigInteger,
		BigText,
		Binary,
		Boolean,
		Byte,
		Char,
		Codeunit,
		Code,
		DateFormula,
		DateTime,
		Date,
		Decimal,
		Dialog,
		DotNet,
		Duration,
		ExecutionMode,
		FieldRef,
		File,
		Guid,
		InStream,
		Integer,
		KeyRef,
		Ocx,
		Option,
		OutStream,
		Page,
		Query,
		RecordID,
		RecordRef,
		Record,
		Report,
		TestPage,
		TextConst,
		Text,
		Time,
		TransactionType,
		Variant,
		Xmlport
	}
}

