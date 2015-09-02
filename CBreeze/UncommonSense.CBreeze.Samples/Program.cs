using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Utils;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            CBreezeWriteDemo(@"c:\users\jhoek\desktop\sample.txt");
            //CBreezeReaderDemo(@"c:\users\jhoek\desktop\sample.txt", @"c:\users\jhoek\desktop\sample.txt");
        }

        static void CBreezeWriteDemo(string outputFileName)
        {
            var range = 50000.To(59999);

            var application = new Application();
            var setupTable = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo Setup"));
            var setupPage = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo Setup"));
            var table = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo"));
            var page = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo Card"));

            setupTable.Fields.Add(new CodeTableField(1, "Primary Key", 10));

            var addNoFromNoSeriesFieldManifest = table.AddNoFromNoSeriesField(range, new Page[] { page }, setupTable, setupPage);
            var addDescriptionFieldsManifest = table.AddDescriptionFields(range, new Page[] { page });
            var addAddressFieldsManifest = table.AddAddressFields(range);

            table.Properties.DataCaptionFields.AddRange(addNoFromNoSeriesFieldManifest.NoField.Name, addDescriptionFieldsManifest.DescriptionField.Name);

            page.Properties.SourceTable = table.ID;
            page.Controls.Add(new ContainerPageControl(0, 0)).Properties.ContainerType = ContainerType.ContentArea;
            page.Controls.Add(new GroupPageControl(0, 1)).Properties.GroupType = GroupType.Group;
            page.Controls.Add(new FieldPageControl(0, 2)).Properties.SourceExpr = "Foo";

            application.Write(outputFileName);

            application.Write(@"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe", @"JANHOEK1FC5\NAVDEMO", "Demo Database NAV (7-0)");
        }

        static void CBreezeReaderDemo(string inputFileName, string outputFileName)
        {
            var application = ApplicationBuilder.FromFile(inputFileName);

            foreach (var table in application.Tables)
            {
                table.Properties.CaptionML["ENU"] = table.Name;
                table.Properties.CaptionML["NLD"] = table.Name.ToUpperInvariant();
                table.Properties.CaptionML["ENU"] = null;

                foreach (var field in table.Fields)
                {
                    field.AllProperties.ByName<MultiLanguageProperty>("CaptionML").Value["ENU"] = field.Name;
                    field.AllProperties.ByName<MultiLanguageProperty>("CaptionML").Value["NLD"] = field.Name.ToUpperInvariant();
                }
            }

            application.Write(outputFileName);
        }
    }
}
