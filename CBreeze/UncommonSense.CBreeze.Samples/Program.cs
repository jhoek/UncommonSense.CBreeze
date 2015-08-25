using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            CBreezeCoreDemo();
            CBreezeWriteDemo(@"c:\users\jhoek\desktop\sample.txt");
            CBreezeReaderDemo(@"c:\users\jhoek\desktop\sample.txt", @"c:\users\jhoek\desktop\sample.txt");
        }

        static void CBreezeCoreDemo()
        {
            var application = new Application();
            application.Tables.Add(new Table(50000, "My Demo Table"));
            application.Tables.Add(new Table(0, "Oink"));
            application.Tables.Add(new Table(0, "Foo"));

            var table = application.Tables["Oink"];

            var codeField = table.Fields.Add(new CodeTableField(1, "Code", 10));
            codeField.Properties.NotBlank = true;
            codeField.Properties.CaptionML.Add("ENU", codeField.Name);

            var descriptionField = table.Fields.Add(new TextTableField(10, "Description", 30));
            descriptionField.Properties.CaptionML.Add("ENU", descriptionField.Name);

            table.Properties.DataCaptionFields.AddRange(codeField.Name, descriptionField.Name);
        }

        static void CBreezeWriteDemo(string outputFileName)
        {
            var application = new Application();
            var table = application.Tables.Add(new Table(50000, "Demo"));
            table.ObjectProperties.DateTime = DateTime.Now;
            table.ObjectProperties.Modified = true;

            table.Properties.PasteIsValid = true;
            table.Properties.Permissions.Add(50000, true, false, false, false);
            table.Properties.OnInsert.Variables.Add(new IntegerVariable(1000, "Foo"));
            table.Properties.OnInsert.Variables.Add(new RecordVariable(0, "Baz", 18));

            table.Fields.Add(new CodeTableField(1, "Primary Key")).Properties.NotBlank = true;
            table.Fields.Add(new TextTableField(0, "Description"));

            var page = application.Pages.Add(new Page(50000, "Demo"));
            page.Controls.Add(new ContainerPageControl(0, 0)).Properties.ContainerType = ContainerType.ContentArea;
            page.Controls.Add(new GroupPageControl(0, 1)).Properties.GroupType = GroupType.Group;
            page.Controls.Add(new FieldPageControl(0, 2)).Properties.SourceExpr = "Foo";
            page.Controls.Insert(2, new FieldPageControl(0, 2)).Properties.SourceExpr = "First";

            var xmlport = application.XmlPorts.Add(new XmlPort(50000, "Demo"));
            xmlport.Nodes.Add(new XmlPortTextElement(Guid.Empty, "Foo", 0));
            xmlport.Nodes.Add(new XmlPortTextElement(Guid.Empty, "Baz", 1));

            application.Write(outputFileName);
        }

        static void CBreezeReaderDemo(string inputFileName, string outputFileName)
        {
            var application = ApplicationBuilder.FromFile(inputFileName);

            foreach (var table in application.Tables)
            {
                if (!table.Properties.CaptionML.Any(e => e.LanguageID == "ENU"))
                    table.Properties.CaptionML.Add("ENU", table.Name);

                foreach (var field in table.Fields)
                {
                    var captionML = field.GetPropertyByName("CaptionML") as MultiLanguageProperty;

                    if (!captionML.Value.Any(e => e.LanguageID == "ENU"))
                        captionML.Value.Add("ENU", field.Name);
                }
            }

            application.Write(outputFileName);
        }
    }
}
