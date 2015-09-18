using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.IO
{
    // FIXME: In additional to the compiler, also create a class for opening pages, reports, running codeunits etc.

    public static class ApplicationCompiler
    {
        public static string Summarize(this IEnumerable<int> ids)
        {
            var groups = ids.Select((n, i) => new
            {
                ID = n,
                Group = n - i
            }).GroupBy(n => n.Group);

            var ranges = groups.Select(g => g.Count() >= 3 ? string.Format("{0}..{1}", g.First().ID, g.Last().ID) : string.Join("|", g.Select(x => x.ID)));

            return string.Join("|", ranges);
        }

        public static void Compile(this Application application, string devClient, string serverName, string database)
        {
            Compile("Table", application.Tables.Select(t => t.ID), devClient, serverName, database);
            Compile("Codeunit", application.Codeunits.Select(c => c.ID), devClient, serverName, database);
            Compile("Page", application.Pages.Select(p => p.ID), devClient, serverName, database);
            Compile("Report", application.Pages.Select(r => r.ID), devClient, serverName, database);

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
