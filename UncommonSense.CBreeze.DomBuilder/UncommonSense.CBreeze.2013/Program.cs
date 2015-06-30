using System;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CBreeze.ObjectModelWriter;

namespace UncommonSense.CBreeze
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var om = new ObjectModel("UncommonSense.CBreeze.70.Core");

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
                .AddChildNode("ObjectProperties")
                .DeriveItem("Table", createContainer: true)
                    .AddChildNode("TableProperties", "Properties")
                    .AddChildNode("TableFields", "Fields")
                    .AddChildNode("Code")
                .AndDeriveItem("Page", createContainer: true)
                	.AddChildNode("PageProperties", "Properties")
                .AndDeriveItem("Report", createContainer: true)
                .AndDeriveItem("Codeunit", createContainer: true)
                	.AddChildNode("CodeunitProperties", "Properties")
                	.AddChildNode("Code")
                .AndDeriveItem("XmlPort", createContainer: true)
                .AndDeriveItem("Query", createContainer: true, containerName: "Queries")
                .AndDeriveItem("MenuSuite", createContainer: true);

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

			om.AddPropertyCollection("CodeunitProperties")
				.AddProperty("NullableBooleanProperty", "CFRONTMayUsePermissions");

			om.AddItem("Parameter", @abstract: true)
				.AddIdentifier("int", "UID")
				.AddIdentifier("string", "Name")
				.AddAttribute("string", "Dimensions")
                .DeriveItem("ActionParameter")
                .AndDeriveItem("IntegerParameter");

			om.AddItem("TableField", @abstract: true, createContainer: true)
				.AddIdentifier("int", "No")
				.AddIdentifier("string", "Name")
				.AddIdentifier("bool?", "Enabled")
				.DeriveItem("BigIntegerTableField")
				.AndDeriveItem("BinaryTableField")
				.AndDeriveItem("BlobTableField");        

			om.AddEnum("BlobSubType", "UserDefined", "Bitmap", "Memo");

			om.WriteToFolder(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
		}
	}
}
