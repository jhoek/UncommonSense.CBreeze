using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.IO
{
    // Reads from Application object, imports into database
    // https://msdn.microsoft.com/nl-nl/library/hh165287(v=nav.90).aspx

    public static class ApplicationImporter
    {
        private static void DoImport(Application application, string devClient, Arguments arguments)
        {
            var fileName = Path.ChangeExtension(Path.GetTempFileName(), "txt");
            arguments.Add("file", fileName);

            try
            {
                application.WriteToFile(fileName);
                DevClient.Run(devClient, arguments);
            }
            finally
            {
                File.Delete(fileName);
            }
        }

#if (NAV2015 || NAV2016)

        public static void Import(this Application application, string devClient, string serverName, string database, ImportAction importAction = ImportAction.Default, SynchronizeSchemaChanges? synchronizeSchemaChanges = null, string navServerName = null, string navServerInstance = null, int? navServerMgtPort = null, string tenant = null)
        {
            var arguments = new Arguments("importobjects", serverName, database);
            arguments.AddIf(importAction != ImportAction.Default, "importaction", (int)importAction);
            arguments.Add("synchronizeschemachanges", synchronizeSchemaChanges?.ToString().ToLowerInvariant());
            arguments.Add("navservername", navServerName);
            arguments.Add("navserverinstance", navServerInstance);
            arguments.Add("navservermanagementport", navServerMgtPort);
            arguments.Add("tenant", tenant);

            DoImport(application, devClient, arguments);
        }

#elif NAV2013R2

        public static void Import(this Application application, string devClient, string serverName, string database, ImportAction importAction = ImportAction.Default, bool? validateTableChanges = null, string navServerName = null, string navServerInstance = null, int? navServerMgtPort = null, string tenant = null)
        {
            var arguments = new Arguments("importobjects", serverName, database);
            arguments.AddIf(importAction != ImportAction.Default, "importaction", (int)importAction);
            arguments.AddIf(validateTableChanges.HasValue, "validatetablechanges", validateTableChanges.Value ? 1 : 0);
            arguments.Add("navservername", navServerName);
            arguments.Add("navserverinstance", navServerInstance);
            arguments.Add("navservermanagementport", navServerMgtPort);
            arguments.Add("tenant", tenant);

            DoImport(application, devClient, arguments);
        }

#else

        public static void Import(this Application application, string devClient, string serverName, string database, ImportAction importAction = ImportAction.Default)
        {
            var arguments = new Arguments("importobjects", serverName, database);
            arguments.AddIf(importAction != ImportAction.Default, "importaction", (int)importAction);

            DoImport(application, devClient, arguments);
        }

#endif
    }
}