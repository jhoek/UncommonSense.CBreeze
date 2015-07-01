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
                .AddChildNode("XmlPorts")
                .AddChildNode("Queries")
                .AddChildNode("MenuSuites");

			om.AddItem("Code")
            	.AddChildNode("Documentation")
            	.AddChildNode("Events")
            	.AddChildNode("Functions")
            	.AddChildNode("Variables");

			om.AddItem("Object", @abstract: true)
                .AddIdentifier("int", "id")
                .AddIdentifier("string", "name")
                .AddChildNode("ObjectProperties");

			om.AddItem("Table", "Object", createContainer: true)
				.AddChildNode("TableProperties", "Properties")
                .AddChildNode("TableFields", "Fields")
                .AddChildNode("Code");

			om.AddItem("Page", "Object", createContainer: true)
            	.AddChildNode("PageProperties", "Properties");

			om.AddItem("Report", "Object", createContainer: true);

			om.AddItem("Codeunit", "Object", createContainer: true)
            	.AddChildNode("CodeunitProperties", "Properties")
            	.AddChildNode("Code");

			om.AddItem("XmlPort", "Object", createContainer: true);

			om.AddItem("Query", "Object", createContainer: true, containerName: "Queries");

			om.AddItem("MenuSuite", "Object", createContainer: true);

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

			om.AddItem("Parameter", @abstract: true)
				.AddIdentifier("int", "UID")
				.AddIdentifier("string", "Name")
				.AddAttribute("string", "Dimensions");

			om.AddItem("ActionParameter", "Parameter");
			om.AddItem("IntegerParameter", "Parameter");

			om.AddItem("Variable", @abstract: true)
            	.AddIdentifier("int", "UID")
            	.AddIdentifier("string", "Name")
            	.AddAttribute("string", "Dimensions");

			om.AddItem("ActionVariable", "Variable");

			om.AddItem("TableField", @abstract: true, createContainer: true)
				.AddIdentifier("int", "No")
				.AddIdentifier("string", "Name")
				.AddAttribute("bool?", "Enabled");

			om.AddItem("BigIntegerTableField", "TableField");
			om.AddItem("BinaryTableField", "TableField");
			om.AddItem("BlobTableField", "TableField");
			om.AddItem("DecimalTableField", "TableField");
			om.AddItem("IntegerTableField", "TableField");

			om.AddEnum("BlobSubType", "UserDefined", "Bitmap", "Memo");

			var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var outputFolderName = Path.Combine(desktopFolderName, "cbreeze");
			Directory.CreateDirectory(outputFolderName);
			om.WriteToFolder(outputFolderName);
		}
	}
}
