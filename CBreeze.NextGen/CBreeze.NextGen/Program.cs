using System;
using System.Linq;

namespace CBreeze.NextGen
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var application = new Application();
			var table = application.Tables.Add(new Table(50000, "Customer Group"));
			var cardPage = application.Pages.Add(new Page(50000, "Customer Group Card"));
			var listPage = application.Pages.Add(new Page(50001, "Customer Group List"));
			var export = application.XmlPorts.Add(new XmlPort(50000, "Export Customer Groups"));

			PrintNode(application, 0);
		}

		private static void AddTable(Application application)
		{
			var table = application.Tables.Add(new Table(50000, "Customer Group"));
			table.ObjectProperties.DateTime = DateTime.Now;
			table.ObjectProperties.Modified = true;
			table.ObjectProperties.VersionList = "NAVJH1.00";

			table.Properties.CaptionML.AddEnu(table.Name);
			table.Properties.LookupPageID = 50000;

			table.Code.Variables.Add(new RecordVariable(1000, "Customer", BaseAppTableID.Customer));
			var function = table.Code.Functions.Add(new Function(1000, "GetTranslation"));
			function.Variables.Add(new RecordVariable(1000, "Item", BaseAppTableID.Item));

			var codeField = table.Fields.Add(new CodeTableField(1, "Code")) as CodeTableField;
			codeField.Properties.CaptionML.AddEnu(codeField.Name);

			var integerField = table.Fields.Add(new IntegerTableField(2, "No. of Customers")) as IntegerTableField;
			integerField.Properties.AltSearchField = "Foo";
		}

		private static void AddPage(Application application)
		{
			var page = application.Pages.Add(new Page(50000, "Customer Groups"));

            
		}

		private static void PrintNode(INode node, int indentation)
		{
			Console.ForegroundColor = node.ChildNodes.OfType<IProperties>().Any() ? ConsoleColor.Yellow : ConsoleColor.Gray;
			Console.Write(new String(' ', indentation * 2));
			Console.WriteLine(node);
			Console.ResetColor();

			foreach (var childNode in node.ChildNodes)
			{
				PrintNode(childNode, indentation + 1);
			}
		}
	}
}
