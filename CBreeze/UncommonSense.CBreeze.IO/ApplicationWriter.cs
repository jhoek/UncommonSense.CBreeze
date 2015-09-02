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
    public static class ApplicationWriter
    {
        public static void Write(this Application application, string devClient, string serverName, string database)
        {
            var fileName = Path.ChangeExtension(Path.GetTempFileName(), "txt");

            var arguments = new Arguments("importobjects", serverName, database);
            arguments.Add("file", fileName);

            try
            {
                application.Write(fileName);
                DevClient.Run(devClient, arguments);
            }
            finally
            {
                File.Delete(fileName);
            }
        }
    }
}
