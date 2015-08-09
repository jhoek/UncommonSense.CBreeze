using System;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CBreeze.ObjectModelWriter;
using System.IO;

namespace UncommonSense.CBreeze
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var om = new ObjectModel("UncommonSense.CBreeze70.Core");

			om.AddItem("Node", @abstract: true)
				.AddIdentifier("Node", "ParentNode");

			om.AddItem("Application")
                .AddChildNode("Tables")
                .AddChildNode("Pages")
                .AddChildNode("Reports")
                .AddChildNode("Codeunits")
				.AddChildNode("Queries")
                .AddChildNode("XmlPorts")
                .AddChildNode("MenuSuites");

			om.AddItem("Object", @abstract: true)
                .AddIdentifier("int", "ID")
                .AddIdentifier("string", "Name")
                .AddChildNode("ObjectProperties");

			om.AddItem("Table", "Object", createContainer: true)
				.Implements("IEquatable<Table>")
				.AddChildNode("TableProperties", "Properties")
                .AddChildNode("TableFields", "Fields")
                .AddChildNode("TableKeys", "Keys")
                .AddChildNode("TableFieldGroups", "FieldGroups")
                .AddChildNode("Code");

			om.AddItem("Page", "Object", createContainer: true)				
            	.AddChildNode("PageProperties", "Properties")
            	.AddChildNode("PageControls", "Controls")
            	.AddChildNode("Code");

			om.AddItem("Report", "Object", createContainer: true)
				.AddChildNode("ReportProperties", "Properties")
				.AddChildNode("ReportElements", "Elements")
				.AddChildNode("ReportLabels", "Labels")
				.AddChildNode("ReportRequestPage", "RequestPage")
				.AddChildNode("Code")
				.AddChildNode("RdlData");

			om.AddItem("Codeunit", "Object", createContainer: true)
            	.AddChildNode("CodeunitProperties", "Properties")
            	.AddChildNode("Code");

			om.AddItem("XmlPort", "Object", createContainer: true)
				.AddChildNode("XmlPortProperties", "Properties")
				.AddChildNode("XmlPortNodes", "Nodes")
				.AddChildNode("XmlPortRequestPage", "RequestPage")
				.AddChildNode("Code");

			om.AddItem("Query", "Object", createContainer: true, containerName: "Queries");

			om.AddItem("MenuSuite", "Object", createContainer: true);

			om.AddItem("Code", createable: false)
            	.AddChildNode("Documentation")
            	.AddChildNode("Events")
				.AddChildNode("Variables")
            	.AddChildNode("Functions");

			om.AddPropertyType("BooleanProperty", "bool");
			om.AddPropertyType("NullableBooleanProperty", "bool?");
			om.AddPropertyType("NullableDateTimeProperty", "DateTime?");
			om.AddPropertyType("NullableIntegerProperty", "int?");
			om.AddPropertyType("MultiLanguageProperty", "MultiLanguageValue");
			om.AddPropertyType("StringProperty", "string");
			om.AddPropertyType("FieldListProperty", "FieldList");
			om.AddPropertyType("ActionListProperty", "ActionList");

			om.AddPropertyCollection("ObjectProperties")
				.AddProperty("NullableDateTimeProperty", "DateTime")
				.AddProperty("BooleanProperty", "Modified")
				.AddProperty("StringProperty", "VersionList");

			om.AddPropertyCollection("TableProperties")
                .AddProperty("MultiLanguageProperty", "CaptionML")
                .AddProperty("FieldListProperty", "DataCaptionFields");

			om.AddPropertyCollection("PageProperties")
            	.AddProperty("ActionListProperty", "ActionList")
            	.AddProperty("NullableBooleanProperty", "AutoSplitKey")
            	.AddProperty("MultiLanguageProperty", "CaptionML")
            	.AddProperty("StringProperty", "CardPageID")
            	.AddProperty("StringProperty", "DataCaptionExpr")
            	.AddProperty("FieldListProperty", "DataCaptionFields")
            	.AddProperty("NullableBooleanProperty", "DelayedInsert");

			om.AddPropertyCollection("IntegerTableFieldProperties");

			om.AddPropertyCollection("CodeunitProperties")
				.AddProperty("NullableBooleanProperty", "CFRONTMayUsePermissions");

			om.AddItem("Parameter", @abstract: true).AddIdentifier("int", "UID").AddIdentifier("string", "Name").AddAttribute("string", "Dimensions");
			om.AddItem("ActionParameter", "Parameter");
			om.AddItem("AutomationParameter", "Parameter").AddIdentifier("string", "SubType");
			om.AddItem("BigIntegerParameter", "Parameter");
			om.AddItem("BigTextParameter", "Parameter");
			om.AddItem("BinaryParameter", "Parameter").AddIdentifier("int", "DataLength");
			om.AddItem("BooleanParameter", "Parameter");
			om.AddItem("ByteParameter", "Parameter");
			om.AddItem("CodeParameter", "Parameter").AddIdentifier("int", "DataLength");
			om.AddItem("IntegerParameter", "Parameter");
			om.AddItem("TimeParameter", "Parameter");
			om.AddItem("TransactionTypeParameter", "Parameter");
			om.AddItem("VariantParameter", "Parameter");
			om.AddItem("XmlPortParameter", "Parameter").AddIdentifier("int", "SubType");

			om.AddItem("Variable", @abstract: true).AddIdentifier("int", "UID").AddIdentifier("string", "Name");
            om.AddItem("ActionVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("AutomationVariable", "Variable").AddIdentifier("string", "SubType").AddAttribute("bool?", "WithEvents").AddAttribute("string", "Dimensions");
            om.AddItem("BigIntegerVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("BigTextVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("BinaryVariable", "Variable").AddIdentifier("int", "DataLength").AddAttribute("string", "Dimensions");
            om.AddItem("BooleanVariable", "Variable").AddAttribute("bool?", "IncludeInDataset").AddAttribute("string", "Dimensions");
            om.AddItem("ByteVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("CharVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("CodeVariable", "Variable").AddIdentifier("int?", "DataLength").AddAttribute("bool?", "IncludeInDataset").AddAttribute("string", "Dimensions");
            om.AddItem("CodeunitVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("string", "Dimensions");
            om.AddItem("DateVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("DateFormulaVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("DateTimeVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("DecimalVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("DialogVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("DotNetVariable", "Variable").AddIdentifier("string", "SubType").AddAttribute("bool?", "RunOnClient").AddAttribute("bool?", "WithEvents").AddAttribute("string", "Dimensions");
            om.AddItem("DurationVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("FieldRefVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("FileVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("GuidVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("InstreamVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("IntegerVariable", "Variable").AddAttribute("bool?", "IncludeInDataset").AddAttribute("string", "Dimensions");
            om.AddItem("KeyRefVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("OcxVariable", "Variable").AddIdentifier("string", "SubType").AddAttribute("string", "Dimensions");
            om.AddItem("OptionVariable", "Variable").AddAttribute("string", "OptionString").AddAttribute("string", "Dimensions");
            om.AddItem("OutstreamVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("PageVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("string", "Dimensions");
            om.AddItem("QueryVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("QuerySecurityFiltering", "SecurityFiltering").AddAttribute("string", "Dimensions");
            om.AddItem("RecordVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("bool?", "Temporary").AddAttribute("RecordSecurityFiltering", "SecurityFiltering").AddAttribute("string", "Dimensions"); // FIXME: Should be nullable?
            om.AddItem("RecordIDVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("RecordRefVariable", "Variable").AddAttribute("RecordSecurityFiltering", "SecurityFiltering").AddAttribute("string", "Dimensions");
            om.AddItem("ReportVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("string", "Dimensions");
            om.AddItem("TextConstant", "Variable").AddAttribute("MultiLanguageValue", "Values");
            om.AddItem("TextVariable", "Variable").AddIdentifier("int", "DataLength").AddAttribute("bool?", "IncludeInDataset").AddAttribute("string", "Dimensions");
            om.AddItem("TimeVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("TransactionTypeVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("VariantVariable", "Variable").AddAttribute("string", "Dimensions");
            om.AddItem("XmlPortVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("string", "Dimensions");

			om.AddItem("TableField", @abstract: true, createContainer: true).AddIdentifier("int", "No").AddIdentifier("string", "Name").AddAttribute("bool?", "Enabled");

			om.AddItem("BigIntegerTableField", "TableField").AddChildNode("BigIntegerTableFieldProperties", "Properties");
			om.AddItem("BinaryTableField", "TableField").AddIdentifier("int", "DataLength").AddChildNode("BinaryTableFieldProperties", "Properties");
			om.AddItem("BlobTableField", "TableField").AddChildNode("BlobTableFieldProperties", "Properties");
			om.AddItem("BooleanTableField", "TableField").AddChildNode("BooleanTableFieldProperties", "Properties");
			om.AddItem("CodeTableField", "TableField").AddIdentifier("int", "DataLength").AddChildNode("CodeTableFieldProperties", "Properties");
			om.AddItem("DecimalTableField", "TableField").AddChildNode("DecimalTableFieldProperties", "Properties");
			om.AddItem("IntegerTableField", "TableField").AddChildNode("IntegerTableFieldProperties", "Properties");
			om.AddItem("TimeTableField", "TableField").AddChildNode("TimeTableFieldProperties", "Properties");

			om.AddItem("CalcFormula")
				.AddAttribute("string", "FieldName")
				.AddAttribute("CalcFormulaMethod", "Method")
				.AddAttribute("bool", "ReverseSign")
				.AddAttribute("CalcFormulaTableFilter", "TableFilter")
				.AddAttribute("string", "TableName");

			om.AddEnum("ActionContainerType", "NewDocumentItems", "ActionItems", "RelatedInformation", "Reports", "HomeItems", "ActivityButtons");
			om.AddEnum("AutoFormatType", "Other", "Amount", "UnitAmount");
			om.AddEnum("BlankNumbers", "DontBlank", "BlankNeg", "BlankNegAndZero", "BlankZero", "BlankZeroAndPos", "BlankPos");
			om.AddEnum("BlobSubType", "UserDefined", "Bitmap", "Memo");
			om.AddEnum("CalcFormulaMethod", "Sum", "Average", "Exist", "Count", "Min", "Max", "Lookup");
			om.AddEnum("CalcFormulaTableFilterType", "Const", "Filter", "Field");
			om.AddEnum("CodeunitSubType", "Normal", "Test", "TestRunner");
			om.AddEnum("ColumnFilterLineType", "Const", "Filter");
			om.AddEnum("ContainerType", "ContentArea", "FactBoxArea", "RoleCenterArea");

			var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var outputFolderName = Path.Combine(desktopFolderName, "cbreezedom");
			Directory.CreateDirectory(outputFolderName);
			om.WriteToFolder(outputFolderName);
		}
	}
}
