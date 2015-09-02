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

            var table = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo").AutoCaption());
            table.ObjectProperties.DateTime = DateTime.Now;

            var table2 = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo 2").AutoCaption());
            table2.ObjectProperties.DateTime = DateTime.Now;

            var cardPage = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo Card").AutoCaption());
            cardPage.ObjectProperties.DateTime = DateTime.Now;
            cardPage.Properties.SourceTable = table.ID;

            var cardPage2 = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo 2 Card").AutoCaption());
            cardPage2.ObjectProperties.DateTime = DateTime.Now;
            cardPage2.Properties.SourceTable = table2.ID;

            var setupTable = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo Setup").AutoCaption());
            setupTable.ObjectProperties.DateTime = DateTime.Now;
            setupTable.Fields.Add(new CodeTableField(range.GetNextPrimaryKeyFieldNo(table), "Primary Key", 10));

            var setupCard = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo Setup").AutoCaption());
            setupCard.ObjectProperties.DateTime = DateTime.Now;
            setupCard.Properties.InsertAllowed = false;
            setupCard.Properties.DeleteAllowed = false;
            setupCard.Properties.PageType = PageType.Card;
            setupCard.Properties.SourceTable = setupTable.ID;

            setupCard.Properties.OnOpenPage.CodeLines.Add("RESET;");
            setupCard.Properties.OnOpenPage.CodeLines.Add("IF NOT GET THEN BEGIN");
            setupCard.Properties.OnOpenPage.CodeLines.Add("  INIT;");
            setupCard.Properties.OnOpenPage.CodeLines.Add("  INSERT;");
            setupCard.Properties.OnOpenPage.CodeLines.Add("END;");

            var addNoFromNoSeriesFieldManifest = table.AddNoFromNoSeriesField(range, cardPage, setupTable, setupCard);
            var addDescriptionFieldsManifest = table.AddDescriptionFields(range);
            var addAddressFieldsManifest = table.AddAddressFields(range);

            table.Properties.DataCaptionFields.AddRange(addNoFromNoSeriesFieldManifest.NoField.Name, addDescriptionFieldsManifest.DescriptionField.Name);

            table2.AddNoFromNoSeriesField(range, cardPage2, setupTable, setupCard);

            //application.Write(outputFileName);

            const string devClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            const string serverName = @"JANHOEK1FC5\NAVDEMO";
            const string database = @"Demo Database NAV (7-0)";

            application.Write(devClient, serverName, database);
            application.Compile(devClient, serverName, database);
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
