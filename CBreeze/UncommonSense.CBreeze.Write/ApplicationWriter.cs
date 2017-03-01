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
        public static void Write(this Application application)
        {
            application.Write(Console.Out);
        }

        public static void Write(this Application application, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream, Encoding.GetEncoding("ibm850")))
            {
                application.Write(streamWriter);
            }
        }

        public static void Write(this Application application, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                application.Write(streamWriter);
            }
        }

        public static void Write(this Application application, TextWriter textWriter)
        {
            application.Write(new CSideWriter(textWriter));
        }

        public static void Write(this Application application, CSideWriter writer)
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