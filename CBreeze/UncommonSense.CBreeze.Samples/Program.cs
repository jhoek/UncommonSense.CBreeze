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

            var demoLedgerEntry = new LedgerEntityTypePattern(application, range, "Demo Ledger Entry");
            var vatEntry = new LedgerEntityTypePattern(application, range, "Another VAT Entry");
            var glEntry = new LedgerEntityTypePattern(application, range, "Another G/L Entry");

            demoLedgerEntry.Apply();
            vatEntry.Apply();
            glEntry.Apply();

            var registerEntityTypePattern = new RegisterEntityTypePattern(application, range, "Demo Register", glEntry.Table, demoLedgerEntry.Table, vatEntry.Table);
            registerEntityTypePattern.HasCreationDate = true;
            registerEntityTypePattern.Apply();

            application.Write(Console.Out);

            const string devClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            const string serverName = @"JANHOEK1FC5\NAVDEMO";
            const string database = @"Demo Database NAV (7-0)";

            application.Write(devClient, serverName, database);
            application.Compile(devClient, serverName, database);
        }
    }
}
