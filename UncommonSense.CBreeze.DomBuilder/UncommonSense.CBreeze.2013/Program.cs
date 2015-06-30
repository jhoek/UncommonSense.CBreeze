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
                .AddChildNode("Reports");

            om.AddItem("Object", @abstract: true)
                .AddIdentifier("int", "id")
                .AddIdentifier("string", "name")
                .DeriveItem("Table", createContainer: true)
                    .AddChildNode("TableProperties", "Properties")
                .AndDeriveItem("Page", createContainer: true);

            om.AddPropertyType("MultiLanguageProperty", "MultiLanguageValue");

            om.AddPropertyCollection("TableProperties")
                .AddProperty("MultiLanguageProperty", "CaptionML");

            om.AddItem("Parameter", @abstract: true)
                .DeriveItem("ActionParameter")
                .AndDeriveItem("IntegerParameter");

            om.AddEnum("BlobSubType", "UserDefined", "Bitmap", "Memo");

			om.WriteToFolder(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
		}
	}
}
