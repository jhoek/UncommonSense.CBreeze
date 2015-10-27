using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.IO
{
    // Reads from database, imports into Application object
    public static class ApplicationExporter
    {
        public static Application Export(string devClient, string serverName, string database, string filter)
        {
            var fileName = Path.ChangeExtension(Path.GetTempFileName(), "txt");

            var arguments = new Arguments("exportobjects", serverName, database);
            arguments.Add("file", fileName);
            arguments.Add("filter", filter);

            try
            {
                DevClient.Run(devClient, arguments);
                return ApplicationBuilder.FromFile(fileName);
            }
            finally
            {
                File.Delete(fileName);
            }
        }
    }
}
