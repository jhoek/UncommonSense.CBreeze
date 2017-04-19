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

            /*
            var xmlport = application.XmlPorts.Add(new XmlPort("My XMLport"));

            xmlport.Nodes.Add(new XmlPortTableElement("Customer")).Properties.SourceTable = BaseApp.TableIDs.Customer;
            xmlport.Nodes.Add(new XmlPortFieldElement("No", 1));
            xmlport.Nodes.Add(new XmlPortFieldElement("Balance", 1));
            xmlport.Nodes.Add(new XmlPortTextAttribute("Currency", 2));

            xmlport.Code.Functions.Add(new Function("Foo")).Local = true;
            xmlport.Code.Variables.Add(new IntegerVariable(9, "MyInteger")).IncludeInDataset = true;
            xmlport.Code.Variables.Add(new TextConstant("Text000")).Values.Set("ENU", "OInk").Set("NLD", "Boink");

            xmlport.Properties.FieldDelimiter = "$";
            */

            var table = application.Tables.Add(new Table("Customer Group"));
            var codeField = table.Fields.Add(new CodeTableField("Code"));
            var descriptionField = table.Fields.Add(new TextTableField("Description"));

            table.Keys.Add(new TableKey(codeField.Name)).Properties.Clustered = true;

            table.Code.Variables.Add(new IntegerVariable("GlobalInt"));
            table.Code.Variables.Add(new TextConstant("Text000")).Values.Set("ENU", "Blaat").Set("NLD", "Klinkt");

            var function = table.Code.Functions.Add(new Function("Foo"));
            function.Parameters.Add(new IntegerParameter("Baz"));
            function.Variables.Add(new IntegerVariable("Bar"));

            table.Properties.DataCaptionFields.AddRange(codeField.Name, descriptionField.Name);

            application.Write();
        }
    }
}