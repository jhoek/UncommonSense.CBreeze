using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var application = new Application();

			var table = application.Tables.Add(new Table(50000, "Customer Group"));
			table.ObjectProperties.DateTime = DateTime.Now;
			table.ObjectProperties.Modified = true;
			table.ObjectProperties.VersionList = "NAVJH1.00";

			table.Properties.CaptionML.Add("ENU", table.Name);
			table.Properties.DataPerCompany = false;
			table.Properties.LookupPageID = 50001;
			table.Properties.DrillDownPageID = 50001;
			table.Properties.Description = "Oink";
			table.Properties.Permissions.Add(50001, new Permission());
			table.Properties.PasteIsValid = true;

			table.Properties.OnInsert.Variables.Add(new RecordVariable(1000, "Foo", BaseAppTableID.Customer));
			table.Properties.OnInsert.Variables.Add(new IntegerVariable(1001, "Baz")).Dimensions = "1,2";

			var codeField = table.Fields.Add(new CodeTableField(1, "Code", 10));
			codeField.Properties.CaptionML.Add("ENU", codeField.Name);
			codeField.Properties.CaptionML.Add("NLD", "Klantgroep");
			codeField.Properties.NotBlank = true;
			table.Properties.DataCaptionFields.Add(codeField.No);

			var integerField = table.Fields.Add(new IntegerTableField(10, "No. of Customers"));
			integerField.Properties.AltSearchField = "Field20";
			table.Properties.DataCaptionFields.Add(integerField.No);

			var primaryKey = table.Keys.Add(new TableKey(codeField.No));
			primaryKey.Properties.Clustered = true;

			table.Keys.Add(new TableKey(integerField.No));

			table.FieldGroups.Add(new TableFieldGroup(1, "DropDown", codeField.No, integerField.No));

			var globalVariable = table.Code.Variables.Add(new RecordVariable(1000, "Foo", BaseAppTableID.Vendor));
			globalVariable.Temporary = true;
			globalVariable.Dimensions = "1,2";
			globalVariable.SecurityFiltering = SecurityFiltering.Validated;

			var function = table.Code.Functions.Add(new Function(1000, "MyFunction"));
			function.Local = true;
			function.Parameters.Add(new IntegerParameter(1000, "MyParameter"));
			function.Parameters.Add(new DateTimeParameter(1001, "MyDateTimeParameter"));

			var variable = function.Variables.Add(new RecordVariable(1000, "MyVariable", 14));
			variable.Temporary = true;

			var cardPage = application.Pages.Add(new Page(50000, "Customer Group Card"));
			cardPage.ObjectProperties.Modified = true;
			cardPage.Properties.CaptionML.Add("ENU", cardPage.Name);

			var pageActionContainer = cardPage.Properties.ActionList.Add(new PageActionContainer(1000, "Foo", 0));
			pageActionContainer.Properties.ActionContainerType = ActionContainerType.RelatedInformation;

			var pageActionGroup = cardPage.Properties.ActionList.Add(new PageActionGroup(1000, "Invalid ID", 1)); 

			var containerControl = cardPage.Controls.Add(new ContainerPageControl(1));
			containerControl.Properties.CaptionML.Add("ENU", "Foo");

			var groupControl = cardPage.Controls.Add(new GroupPageControl(2));
			groupControl.Properties.CaptionML.Add("ENU", "Baz");

			var codeunit = application.Codeunits.Add(new Codeunit(50000, "Customer Group Mgt."));
			codeunit.Properties.TableNo = 50000;

			var query = application.Queries.Add(new Query(50000, "Customer Groups"));
			query.ObjectProperties.DateTime = DateTime.Now;
			query.ObjectProperties.VersionList = "NAVJH1.00";

			var root = query.Elements.Add(new QueryColumnElement(1, "Root", 0));
			root.Properties.CaptionML.Add("ENU", "Foo");

			var xmlPort = application.XmlPorts.Add(new XmlPort(50000, "Export Customer Groups"));
			xmlPort.ObjectProperties.DateTime = DateTime.Now;
			xmlPort.ObjectProperties.VersionList = "NAVJH1.00";

			var xmlPortRootNode = xmlPort.Nodes.Add(new XmlPortTableElementNode(1, "Foo", 0));
			xmlPortRootNode.Properties.AutoReplace = true;

			var xmlPortTextElementNode = xmlPort.Nodes.Add(new XmlPortTextElementNode(2, "Baz", 1));
			xmlPortTextElementNode.Properties.MaxOccurs = MaxOccurs.Unbounded;

			var xmlPortFunction = xmlPort.Code.Functions.Add(new Function(1000, "MyFunction"));
			xmlPortFunction.Local = true;

			PrintNode(application, 0);
		}

		private static void PrintNode(INode node, int indentation)
		{
			Console.Write(new String(' ', indentation * 2));
			Console.Write(node);

			if (node is Property)
			{
				Console.Write(" [{0}]", (node as Property).HasValue);
			}

			Console.WriteLine();

			foreach (var childNode in node.ChildNodes)
			{
				PrintNode(childNode, indentation + 1);
			}
		}
	}
}
