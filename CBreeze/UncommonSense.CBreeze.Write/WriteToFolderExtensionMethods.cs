using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class WriteToFolderExtensionMethods
    {
        public static void WriteToFolder(this Application application, string folderName)
        {
            Directory.CreateDirectory(folderName);

            application.Tables.ForEach(t => t.WriteToFolder(folderName));
            application.Pages.ForEach(p => p.WriteToFolder(folderName));
            application.Reports.ForEach(r => r.WriteToFolder(folderName));
            application.Codeunits.ForEach(c => c.WriteToFolder(folderName));
            application.Queries.ForEach(q => q.WriteToFolder(folderName));
            application.XmlPorts.ForEach(x => x.WriteToFolder(folderName));
            application.MenuSuites.ForEach(m => m.WriteToFolder(folderName));
        }

        public static void WriteToFolder(this Table table, string folderName) => table.Write(Path.Combine(folderName, $"tab{table.ID}.txt"));

        public static void WriteToFolder(this Page page, string folderName) => page.Write(Path.Combine(folderName, $"pag{page.ID}.txt"));

        public static void WriteToFolder(this Report report, string folderName) => report.Write(Path.Combine(folderName, $"rep{report.ID}.txt"));

        public static void WriteToFolder(this Codeunit codeunit, string folderName) => codeunit.Write(Path.Combine(folderName, $"cod{codeunit.ID}.txt"));

        public static void WriteToFolder(this Query query, string folderName) => query.Write(Path.Combine(folderName, $"que{query.ID}.txt"));

        public static void WriteToFolder(this XmlPort xmlPort, string folderName) => xmlPort.Write(Path.Combine(folderName, $"xml{xmlPort.ID}.txt"));

        public static void WriteToFolder(this MenuSuite menuSuite, string folderName) => menuSuite.Write(Path.Combine(folderName, $"men{menuSuite.ID}.txt"));

        public static void Write(this Table table, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                table.Write(streamWriter);
            }
        }

        public static void Write(this Page page, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                page.Write(streamWriter);
            }
        }

        public static void Write(this Report report, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                report.Write(streamWriter);
            }
        }

        public static void Write(this Codeunit codeunit, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                codeunit.Write(streamWriter);
            }
        }

        public static void Write(this Query query, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                query.Write(streamWriter);
            }
        }

        public static void Write(this XmlPort xmlPort, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                xmlPort.Write(streamWriter);
            }
        }

        public static void Write(this MenuSuite menuSuite, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                menuSuite.Write(streamWriter);
            }
        }

        public static void Write(this Table table, TextWriter textWriter) => table.Write(new CSideWriter(textWriter));

        public static void Write(this Page page, TextWriter textWriter) => page.Write(new CSideWriter(textWriter));

        public static void Write(this Report report, TextWriter textWriter) => report.Write(new CSideWriter(textWriter));

        public static void Write(this Codeunit codeunit, TextWriter textWriter) => codeunit.Write(new CSideWriter(textWriter));

        public static void Write(this Query query, TextWriter textWriter) => query.Write(new CSideWriter(textWriter));

        public static void Write(this XmlPort xmlPort, TextWriter textWriter) => xmlPort.Write(new CSideWriter(textWriter));

        public static void Write(this MenuSuite menuSuite, TextWriter textWriter) => menuSuite.Write(new CSideWriter(textWriter));
    }
}
