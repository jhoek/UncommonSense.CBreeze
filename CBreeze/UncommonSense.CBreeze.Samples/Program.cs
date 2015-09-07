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
            CBreezeWriteDemo();
        }

        static void CBreezeWriteDemo()
        {
            var range = 50000.To(59999);

            var application = new Application();

            var table = application.Tables.Add(new Table(range.GetNextTableID(application), "Demo").AutoCaption());
            table.ObjectProperties.DateTime = DateTime.Now;

            var cardPage = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo Card").AutoCaption());
            cardPage.ObjectProperties.DateTime = DateTime.Now;
            cardPage.Properties.PageType = PageType.Card;
            cardPage.Properties.SourceTable = table.ID;

            var listPage = application.Pages.Add(new Page(range.GetNextPageID(application), "Demo List").AutoCaption());
            listPage.ObjectProperties.DateTime = DateTime.Now;
            listPage.Properties.PageType = PageType.List;
            listPage.Properties.SourceTable = table.ID;
            listPage.Properties.CardPageID = cardPage.Name;

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

            // ===
            var noSeriesFieldsManifest = table.AddNoSeriesFields(range, setupTable, setupCard);
            cardPage.AddNoSeriesControls(noSeriesFieldsManifest, range);
            listPage.AddNoSeriesControls(noSeriesFieldsManifest, range);

            var descriptionFieldsManifest = table.AddDescriptionFields(range, DescriptionStyle.Name, prefix: "Ship-To ");
            cardPage.AddDescriptionControls(descriptionFieldsManifest, "General", range, Position.LastWithinContainer);
            listPage.AddDescriptionControls(descriptionFieldsManifest, "General", range, Position.LastWithinContainer);

            var addressFieldsManifest = table.AddAddressFields( range, "Ship-To ");
            cardPage.AddAddressControls(addressFieldsManifest, "General", range, Position.FirstWithinContainer);
            listPage.AddAddressControls(addressFieldsManifest, "General", range, Position.FirstWithinContainer);

            var communicationFieldsManifest = table.AddCommunicationFields(range, prefix: "Ship-To ");
            cardPage.AddCommunicationControls(communicationFieldsManifest, range, Position.LastWithinContainer);
            listPage.AddCommunicationControls(communicationFieldsManifest, range, Position.LastWithinContainer);

            //table.Properties.DataCaptionFields.AddRange(noSeriesFieldsManifest.NoField.Name, addDescriptionFieldsManifest.DescriptionField.Name);

            const string devClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            const string serverName = @"JANHOEK1FC5\NAVDEMO";
            const string database = @"Demo Database NAV (7-0)";

            application.Write(devClient, serverName, database);
            application.Compile(devClient, serverName, database);
        }
    }
}
