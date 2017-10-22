using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class ApplicationWriter
    {
        public static void WriteToStdOut(this Application application)
        {
            application.WriteToTextWriter(Console.Out);
        }

        public static void WriteToStream(this Application application, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream, Encoding.GetEncoding("ibm850")))
            {
                application.WriteToTextWriter(streamWriter);
            }
        }

        public static void WriteToFile(this Application application, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                application.WriteToTextWriter(streamWriter);
            }
        }

        public static void WriteToTextWriter(this Application application, TextWriter textWriter)
        {
            application.WriteToCSideWriter(new CSideWriter(textWriter));
        }

        public static void WriteToCSideWriter(this Application application, CSideWriter writer)
        {
            application.Tables.Write(writer);
            application.Reports.Write(writer);
            application.Codeunits.Write(writer);
            application.XmlPorts.Write(writer);
            application.MenuSuites.Write(writer);
            application.Pages.Write(writer);
            application.Queries.Write(writer);
        }
    }
}