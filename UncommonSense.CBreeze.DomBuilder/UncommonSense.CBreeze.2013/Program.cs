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

			om.AddItem("Code")
            	.AddChildNode("Documentation")
            	.AddChildNode("Events")
            	.AddChildNode("Functions")
            	.AddChildNode("Variables");

			om.AddPropertyType("BooleanProperty", "bool");
			om.AddPropertyType("NullableBooleanProperty", "bool?");
			om.AddPropertyType("NullableDateTimeProperty", "DateTime?");
			om.AddPropertyType("NullableIntegerProperty", "int?");
			om.AddPropertyType("MultiLanguageProperty", "MultiLanguageValue");
			om.AddPropertyType("StringProperty", "string");

			om.AddPropertyCollection("ObjectProperties")
				.AddProperty("NullableDateTimeProperty", "DateTime")
				.AddProperty("BooleanProperty", "Modified")
				.AddProperty("StringProperty", "VersionList");

			om.AddPropertyCollection("TableProperties")
                .AddProperty("MultiLanguageProperty", "CaptionML")
                .AddProperty("FieldListProperty", "DataCaptionFields");

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
			om.AddItem("IntegerParameter", "Parameter");
			om.AddItem("TimeParameter", "Parameter");
			om.AddItem("TransactionTypeParameter", "Parameter");
			om.AddItem("VariantParameter", "Parameter");
			om.AddItem("XmlPortParameter", "Parameter").AddIdentifier("int", "SubType");

			om.AddItem("Variable", @abstract: true).AddIdentifier("int", "UID").AddIdentifier("string", "Name").AddAttribute("string", "Dimensions");
			om.AddItem("ActionVariable", "Variable");
			om.AddItem("AutomationVariable", "Variable").AddIdentifier("string", "SubType").AddAttribute("bool?", "WithEvents");
			om.AddItem("BigIntegerVariable", "Variable");
			om.AddItem("BigTextVariable", "Variable");
			om.AddItem("BinaryVariable", "Variable").AddIdentifier("int", "DataLength");
			om.AddItem("BooleanVariable", "Variable").AddAttribute("bool?", "IncludeInDataset");
			om.AddItem("ByteVariable", "Variable");
			om.AddItem("CharVariable", "Variable");
			om.AddItem("CodeVariable", "Variable").AddIdentifier("int?", "DataLength").AddAttribute("bool?", "IncludeInDataset");
			om.AddItem("CodeunitVariable", "Variable").AddIdentifier("int", "SubType");
			om.AddItem("DateVariable", "Variable");
			om.AddItem("DateFormulaVariable", "Variable");
			om.AddItem("DateTimeVariable", "Variable");
			om.AddItem("DecimalVariable", "Variable");
			om.AddItem("DialogVariable", "Variable");
			om.AddItem("DotNetVariable", "Variable").AddIdentifier("string", "SubType").AddAttribute("bool?", "RunOnClient").AddAttribute("bool?", "WithEvents"); 
			om.AddItem("DurationVariable", "Variable");
			om.AddItem("FieldRefVariable", "Variable");
			om.AddItem("FileVariable", "Variable");
			om.AddItem("GuidVariable", "Variable");
			om.AddItem("InstreamVariable", "Variable");
			om.AddItem("IntegerVariable", "Variable").AddAttribute("bool?", "IncludeInDataset");
			om.AddItem("KeyRefVariable", "Variable");
			om.AddItem("RecordVariable", "Variable").AddIdentifier("int", "SubType").AddAttribute("bool?", "Temporary").AddAttribute("RecordSecurityFiltering", "SecurityFiltering"); // FIXME: Should be nullable?
			om.AddItem("TextVariable", "Variable").AddIdentifier("int", "DataLength").AddAttribute("bool?", "IncludeInDataset");
			om.AddItem("TimeVariable", "Variable");
			om.AddItem("TransactionTypeVariable", "Variable");
			om.AddItem("VariantVariable", "Variable");
			om.AddItem("XmlPortVariable", "Variable").AddIdentifier("int", "SubType");

			om.AddItem("TableField", @abstract: true, createContainer: true).AddIdentifier("int", "No").AddIdentifier("string", "Name").AddAttribute("bool?", "Enabled");

			om.AddItem("BigIntegerTableField", "TableField").AddChildNode("BigIntegerTableFieldProperties", "Properties");
			om.AddItem("BinaryTableField", "TableField").AddIdentifier("int", "DataLength").AddChildNode("BinaryTableFieldProperties", "Properties");
			om.AddItem("BlobTableField", "TableField").AddChildNode("BlobTableFieldProperties", "Properties");
			om.AddItem("BooleanTableField", "TableField").AddChildNode("BooleanTableFieldProperties", "Properties");
			om.AddItem("DecimalTableField", "TableField");
			om.AddItem("IntegerTableField", "TableField");
			om.AddItem("TimeTableField", "TableField").AddChildNode("TimeTableFieldProperties", "Properties");

			om.AddItem("CalcFormula")
				.AddAttribute("string", "FieldName")
				.AddAttribute("CalcFormulaMethod", "Method")
				.AddAttribute("bool", "ReverseSign")
				.AddAttribute("CalcFormulaTableFilter", "TableFilter")
				.AddAttribute("string", "TableName");

			om.AddEnum("BlobSubType", "UserDefined", "Bitmap", "Memo");

			var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var outputFolderName = Path.Combine(desktopFolderName, "cbreeze");
			Directory.CreateDirectory(outputFolderName);
			om.WriteToFolder(outputFolderName);
		}
	}
}
