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

            var table = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo"));
            table.ObjectProperties.DateTime = DateTime.Now;

            var cardPage = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo Card"));
            cardPage.Properties.SourceTable = table.ID;

            var setupTable = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo Setup"));
            setupTable.ObjectProperties.DateTime = DateTime.Now;
            setupTable.Fields.Add(new CodeTableField(range.GetNextPrimaryKeyFieldNo(table), "Primary Key", 10));

            var addNoFromNoSeriesFieldManifest = table.AddNoFromNoSeriesField(range, setupTable, cardPage);
            var addDescriptionFieldsManifest = table.AddDescriptionFields(range);
            var addAddressFieldsManifest = table.AddAddressFields(range);

            table.Properties.DataCaptionFields.AddRange(addNoFromNoSeriesFieldManifest.NoField.Name, addDescriptionFieldsManifest.DescriptionField.Name);

            //application.Write(outputFileName);

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
