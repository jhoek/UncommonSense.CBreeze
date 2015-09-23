using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Meta;
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

            var setupEntityType = new SetupEntityTypePattern(application, range, "Demo Setup");
            setupEntityType.Apply();

            var newItem = new MasterEntityTypePattern(application, range, "New Item");
            newItem.SetupTable = setupEntityType.Table;
            newItem.SetupPage = setupEntityType.Page;
            newItem.Apply();

            var newVendor = new MasterEntityTypePattern(application, range, "New Vendor");
            newVendor.SetupTable = setupEntityType.Table;
            newVendor.SetupPage = setupEntityType.Page;
            newVendor.Apply();

            var subsidiaryEntityType = new SubsidiaryEntityTypePattern(application, range, "New Item Vendor", newItem.Table, newVendor.Table);
            subsidiaryEntityType.DifferentiatorType = DifferentiatorType.Code;
            subsidiaryEntityType.Apply();

            var journalEntityType = new JournalEntityTypePattern(application, range, "New Item Journal");
            journalEntityType.MasterEntityTypeTable = newItem.Table;
            journalEntityType.Apply();

            /*
            var demoLedgerEntry = new LedgerEntityTypePattern(application, range, "Demo Ledger Entry");
            demoLedgerEntry.PluralName = "Demo Ledger Entries";
            
            var vatEntry = new LedgerEntityTypePattern(application, range, "Another VAT Entry");
            vatEntry.PluralName = "Other VAT Entries";

            var glEntry = new LedgerEntityTypePattern(application, range, "Another G/L Entry");
            glEntry.PluralName = "Other G/L Entries";

            demoLedgerEntry.Apply();
            vatEntry.Apply();
            glEntry.Apply();

            var registerEntityTypePattern = new RegisterEntityTypePattern(application, range, "Demo Register", glEntry.Table, demoLedgerEntry.Table, vatEntry.Table);
            registerEntityTypePattern.HasCreationDate = true;
            registerEntityTypePattern.Apply();
             */

            //application.Write(Console.Out);

            const string devClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            const string databaseServerName = @"JANHOEK1FC5\NAVDEMO";
            const string databaseName = @"Demo Database NAV (7-0)";

            application.Write(devClient, databaseServerName, databaseName);
            application.Compile(devClient, databaseServerName, databaseName);

            const string roleTailoredClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\Microsoft.Dynamics.Nav.Client.exe";
            const string serverName = "localhost";
            const int serverPort = 7146;
            const string serverInstance = "DynamicsNAV70";
            const string companyName = "CRONUS Nederland BV";

            //registerEntityTypePattern.Table.Run(roleTailoredClient, serverName, serverPort, serverInstance, companyName);
            //demoLedgerEntry.Page.Run(roleTailoredClient, serverName, serverPort, serverInstance, companyName, PageMode.Edit);
            //subsidiaryEntityType.Page.Run(roleTailoredClient, serverName, serverPort, serverInstance, companyName, PageMode.View);
            journalEntityType.JournalPage.Run(roleTailoredClient, serverName, serverPort, serverInstance, companyName, PageMode.View);
        }
    }
}
