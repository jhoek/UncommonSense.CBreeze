﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;

namespace UncommonSense.CBreeze.IO
{
    public static class ApplicationCompiler
    {
        public static void Compile(this Application application, string devClient, string serverName, string database)
        {
            Compile("Table", application.Tables.Select(t => t.ID), devClient, serverName, database);
            Compile("Codeunit", application.Codeunits.Select(c => c.ID), devClient, serverName, database);
            Compile("Page", application.Pages.Select(p => p.ID), devClient, serverName, database);
            Compile("Report", application.Reports.Select(r => r.ID), devClient, serverName, database);
            Compile("XMLport", application.XmlPorts.Select(x => x.ID), devClient, serverName, database);
            Compile("Query", application.Queries.Select(x => x.ID), devClient, serverName, database);
            Compile("MenuSuite", application.MenuSuites.Select(m => m.ID), devClient, serverName, database);
        }

        public static void Compile(string type, IEnumerable<int> ids, string devClient, string serverName, string database)
        {
            if (!ids.Any())
                return;

            var filter = string.Format("Type={0};ID={1}", type, ids.Summarize());
            var arguments = new Arguments("compileobjects", serverName, database);
            arguments.Add("filter", filter);

            DevClient.Run(devClient, arguments);
        }
    }
}
