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
            DefaultRanges.ID = Enumerable.Range(50000, 1000);
            DefaultRanges.UID = Enumerable.Range(1000000000, 1000);

            var application = new Application();
            var table = application.Tables.Add(new Table("MyTable"));
            var page = application.Pages.Add(new Page("MyPage"));
            var report = application.Reports.Add(new Report("MyReport"));
            var xmlPort = application.XmlPorts.Add(new XmlPort("MyXmlPort"));
            var query = application.Queries.Add(new Query("MyQuery"));
            var codeunit = application.Codeunits.Add(new Codeunit("MyCodeunit"));
            var menuSuite = application.MenuSuites.Add(new MenuSuite("MyMenuSuite"));

            // FIXME: ParentID in zelfde range => dan nummeren van 1
            table.FieldGroups.Add(new TableFieldGroup(TableFieldGroup.DropDown, "Foo", "Baz"));
            table.FieldGroups.Add(new TableFieldGroup(TableFieldGroup.Brick, "Oink", "BOink"));

            page.Actions.Add(new PageActionContainer(containerType: ActionContainerType.ActionItems));
            page.Actions.Add(new PageActionGroup(0, 1));

            page.Controls.Add(new ContainerPageControl(0, 0, ContainerType.ContentArea));
            page.Controls.Add(new GroupPageControl(0, 1, GroupType.Repeater));

            var function = page.Code.Functions.Add(new Function(0, "Foo"));
            function.Parameters.Add(new IntegerParameter("MyParam"));
            function.Parameters.Add(new BigTextParameter("MyBigText"));
            function.Parameters.Add(new TextParameter("MyText", dataLength: 80, var: true));
            function.Variables.Add(new IntegerVariable(0, "Oink"));
            function.Variables.Add(new IntegerVariable(0, "Boink"));

            var function2 = page.Code.Functions.Add(new Function("Baz"));

            report
                .Labels
                .Add(new ReportLabel("MyLabel"))
                .Properties
                .CaptionML
                .Set("ENU", "Foo")
                .Set("NLD", "Baz");

            report.Elements.Add(new DataItemReportElement(BaseApp.TableIDs.Customer));
            report.Elements.Add(new ColumnReportElement("No", "No."));

            codeunit.Code.Variables.Add(new ActionVariable("MyActionVariable"));

            application.Write();
        }
    }
}