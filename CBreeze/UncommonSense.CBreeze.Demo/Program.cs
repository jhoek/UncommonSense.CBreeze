using System;
using System.Linq;
using System.Diagnostics;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;
using UncommonSense.CBreeze.Read;
using System.IO;
using System.Text;

namespace UncommonSense.CBreeze.Demo
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            DefaultRanges.ID = Enumerable.Range(50000, 100);
            DefaultRanges.UID = Enumerable.Range(1000000000, 100);

            var application = new Application();

            //var table = SetupTable(application.Tables.Add(new Table("MyTable")));
            //var table2 = SetupTable(application.Tables.Add(new Table(1, "MyOtherTable")));

            var page = SetupPage(application.Pages.Add(new Page("MyPage")));

            //var report = SetupReport(application.Reports.Add(new Report("MyReport")));
            //var xmlPort = SetupXmlPort(application.XmlPorts.Add(new XmlPort("MyXmlPort")));
            //var query = SetupQuery(application.Queries.Add(new Query("MyQuery")));
            //var codeunit = SetupCodeunit(application.Codeunits.Add(new Codeunit("MyCodeunit")));
            //var menuSuite = SetupMenuSuite(application.MenuSuites.Add(new MenuSuite("MyMenuSuite")));

            // FIXME: ParentID in zelfde range => dan nummeren van 1
            application.Write();
        }

        private static Codeunit SetupCodeunit(Codeunit codeunit)
        {
            codeunit.Code.Variables.Add(new ActionVariable("MyActionVariable"));
            return codeunit;
        }

        private static MenuSuite SetupMenuSuite(MenuSuite menuSuite)
        {
            return menuSuite;
        }

        private static Page SetupPage(Page page)
        {
            page.Actions.Add(new PageActionContainer(containerType: ActionContainerType.ActionItems));
            page.Actions.Add(new PageActionGroup(0, 1));

            page.Controls.Add(new ContainerPageControl());
            page.Controls.Add(new GroupPageControl(indentationLevel: 1, groupType: GroupType.Repeater));
            page.Controls.Add(new FieldPageControl("MyField", indentationLevel: 2));

            var function = page.Code.Functions.Add(new Function(0, "Foo"));
            function.Parameters.Add(new IntegerParameter("MyParam"));
            function.Parameters.Add(new BigTextParameter("MyBigText"));
            function.Parameters.Add(new TextParameter("MyText", dataLength: 80, var: true));
            function.Variables.Add(new IntegerVariable(0, "Oink"));
            function.Variables.Add(new IntegerVariable(0, "Boink"));

            var function2 = page.Code.Functions.Add(new Function("Baz"));

            return page;
        }

        private static Query SetupQuery(Query query)
        {
            query.Elements.Add(new DataItemQueryElement(BaseApp.TableIDs.Customer));
            query.Elements.Add(new FilterQueryElement("No.", indentationLevel: 1));
            query.Elements.Add(new ColumnQueryElement("Name", indentationLevel: 1));

            return query;
        }

        private static Report SetupReport(Report report)
        {
            report
                .Labels
                .Add(new ReportLabel("MyLabel"))
                .Properties
                .CaptionML
                .Set("ENU", "Foo")
                .Set("NLD", "Baz");

            report.Elements.Add(new DataItemReportElement(BaseApp.TableIDs.Customer));
            report.Elements.Add(new ColumnReportElement("No", "No."));

            return report;
        }

        private static Table SetupTable(Table table)
        {
            table.Fields.Add(new IntegerTableField("Foo"));
            table.Fields.Add(new CodeTableField("Baz"));

            table.Keys.Add(new TableKey("Foo"));

            table.FieldGroups.Add(new TableFieldGroup(TableFieldGroup.DropDown, "Foo", "Baz"));
            table.FieldGroups.Add(new TableFieldGroup(TableFieldGroup.Brick, "Oink", "BOink"));

            var function = table.Code.Functions.Add(new Function("MyFunction"));
            function.Parameters.Add(new TextParameter("MyTextParameter", true));

            return table;
        }

        private static XmlPort SetupXmlPort(XmlPort xmlPort)
        {
            return xmlPort;
        }
    }
}