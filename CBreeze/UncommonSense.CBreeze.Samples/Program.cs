using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Patterns;
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
            //var noSeriesFieldsManifest = table.AddNoSeriesFields(range, setupTable, setupCard);
            //cardPage.AddNoSeriesControls(noSeriesFieldsManifest, range);
            //listPage.AddNoSeriesControls(noSeriesFieldsManifest, range);

            var noSeriesPattern = new NoSeriesPattern(range, table, cardPage, listPage);
            noSeriesPattern.SetupTable = setupTable;
            noSeriesPattern.SetupPage = setupCard;
            noSeriesPattern.Apply();

            var shipToNamePattern = new DescriptionPattern(range,table,cardPage, listPage);
            shipToNamePattern.Style = DescriptionPattern.DescriptionStyle.Name;
            shipToNamePattern.Prefix = "Ship-to ";
            shipToNamePattern.GroupCaption = "Shipping";
            shipToNamePattern.Apply();

            var shipToAddressBlockPattern = new AddressBlockPattern(range, table, cardPage, listPage);
            shipToAddressBlockPattern.Prefix = "Ship-to ";
            shipToAddressBlockPattern.GroupCaption = "General";
            shipToAddressBlockPattern.CardPageGroupPosition = Position.FirstWithinContainer;
            shipToAddressBlockPattern.Apply();

            var billToNamePattern = new DescriptionPattern(range, table, cardPage, listPage);
            billToNamePattern.Style = DescriptionPattern.DescriptionStyle.Name;
            billToNamePattern.Prefix = "Bill-to ";
            billToNamePattern.GroupCaption = "Invoicing";
            billToNamePattern.Apply();

            var billToAddressBlockPattern = new AddressBlockPattern(range,table,cardPage, listPage);
            billToAddressBlockPattern.Prefix = "Bill-to ";
            billToAddressBlockPattern.GroupCaption = "Invoicing";
            billToAddressBlockPattern.Apply();

            var communicationFieldsManifest = table.AddCommunicationFields(range, prefix: "Ship-To ");
            cardPage.AddCommunicationControls(communicationFieldsManifest, range, Position.LastWithinContainer);
            listPage.AddCommunicationControls(communicationFieldsManifest, range, Position.LastWithinContainer);

            // FIXME: table.Properties.DataCaptionFields.AddRange(noSeriesFieldsManifest.NoField.Name, descriptionFieldsManifest.DescriptionField.Name);

            const string devClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            const string serverName = @"JANHOEK1FC5\NAVDEMO";
            const string database = @"Demo Database NAV (7-0)";

            application.Write(devClient, serverName, database);
            application.Compile(devClient, serverName, database);
        }
    }
}
