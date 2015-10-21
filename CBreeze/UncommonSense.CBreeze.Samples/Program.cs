using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Meta;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Utils;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Samples
{
    class Program
    {
        const string devClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
        const string databaseServerName = @"JANHOEK1FC5\NAVDEMO";
        const string databaseName = @"Demo Database NAV (7-0)";

        const string roleTailoredClient = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\Microsoft.Dynamics.Nav.Client.exe";
        const string serverName = "localhost";
        const int serverPort = 7146;
        const string serverInstance = "DynamicsNAV70";
        const string companyName = "CRONUS Nederland BV";

        static void Main(string[] args)
        {
            var application = new Application();
            var range = 50000.To(59999);

            AddressBlock(application, range);
            //JournalEntityType(application, range);
        }

        static void AddressBlock(Application application, IEnumerable<int> range)
        {
            var codeunit = application.Codeunits.Add(new Codeunit(50000, "New Format Address"));
            var table = application.Tables.Add(new Table(range.GetNextTableID(application), "New Customer"));

            //var descriptionPattern = new DescriptionPattern(range, table);
            //descriptionPattern.Style = DescriptionStyle.Name;
            //descriptionPattern.Prefix = "Ship-to ";
            //descriptionPattern.Apply();

            //var communicationPattern = new CommunicationPattern(range, table);
            //communicationPattern.Prefix = "Ship-to ";
            //communicationPattern.Apply();

            //var addressBlockPattern = new AddressBlockPattern(range, table);
            //addressBlockPattern.FormatAddressCodeunit = codeunit;
            //addressBlockPattern.Prefix = "Ship-to ";
            //addressBlockPattern.Apply();

            var formatAddrFunction = codeunit.Code.Functions.Add(new Function(range.GetNextFunctionID(codeunit), "FormatAddr"));
            formatAddrFunction.Parameters.Add(new TextParameter(true, range.GetNextParameterID(formatAddrFunction), "AddrArray", 90)).Dimensions = "8";
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "Name", 90));
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "Name2", 90));
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "Contact", 90));
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "Addr", 50));
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "Addr2", 50));
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "City", 50));
            formatAddrFunction.Parameters.Add(new CodeParameter(false, range.GetNextParameterID(formatAddrFunction), "PostCode", 20));
            formatAddrFunction.Parameters.Add(new TextParameter(false, range.GetNextParameterID(formatAddrFunction), "County", 50));
            formatAddrFunction.Parameters.Add(new CodeParameter(false, range.GetNextParameterID(formatAddrFunction), "CountryCode", 10));

            application.Write(devClient, databaseServerName, databaseName);
            application.Compile(devClient, databaseServerName, databaseName);

            codeunit.Design(devClient, databaseServerName, databaseName);
        }

        static void JournalEntityType(Application application, IEnumerable<int> range)
        {
            var setupEntityType = new SetupEntityTypePattern(application, range, "Demo Setup");
            //setupEntityType.Apply();

            var masterEntityType = new MasterEntityTypePattern(application, range, "New Item");
            masterEntityType.SetupTable = setupEntityType.Table;
            masterEntityType.SetupPage = setupEntityType.Page;
            masterEntityType.HasDescription2 = true;
            masterEntityType.HasSearchDescription = true;
            masterEntityType.HasStatisticsPage=true;
            masterEntityType.HasLastDateModified = true;
            //masterEntityType.Apply();

            var journalEntityType = new JournalEntityTypePattern(application, range, "New Item Journal");
            journalEntityType.MasterEntityTypeTable = masterEntityType.Table;
            //journalEntityType.Apply();

            application.Write(devClient, databaseServerName, databaseName);
            application.Compile(devClient, databaseServerName, databaseName);

            masterEntityType.CardPage.Run(roleTailoredClient, serverName, serverPort, serverInstance, companyName, PageMode.View);
        }
    }
}
