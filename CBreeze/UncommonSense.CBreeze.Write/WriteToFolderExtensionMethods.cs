using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.XmlPort;
using Object = UncommonSense.CBreeze.Core.Base.Object;

namespace UncommonSense.CBreeze.Write
{
    public static class WriteToFolderExtensionMethods
    {
        public static FileInfo Write(this Table table, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                table.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static FileInfo Write(this Page page, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                page.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static FileInfo Write(this Report report, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                report.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static FileInfo Write(this Codeunit codeunit, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                codeunit.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static FileInfo Write(this Query query, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                query.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static FileInfo Write(this XmlPort xmlPort, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                xmlPort.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static FileInfo Write(this MenuSuite menuSuite, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("ibm850")))
            {
                menuSuite.Write(streamWriter);
            }

            return new FileInfo(fileName);
        }

        public static void Write(this Table table, TextWriter textWriter) => table.Write(new CSideWriter(textWriter));

        public static void Write(this Page page, TextWriter textWriter) => page.Write(new CSideWriter(textWriter));

        public static void Write(this Report report, TextWriter textWriter) => report.Write(new CSideWriter(textWriter));

        public static void Write(this Codeunit codeunit, TextWriter textWriter) => codeunit.Write(new CSideWriter(textWriter));

        public static void Write(this Query query, TextWriter textWriter) => query.Write(new CSideWriter(textWriter));

        public static void Write(this XmlPort xmlPort, TextWriter textWriter) => xmlPort.Write(new CSideWriter(textWriter));

        public static void Write(this MenuSuite menuSuite, TextWriter textWriter) => menuSuite.Write(new CSideWriter(textWriter));

        public static IEnumerable<FileInfo> WriteToFolder(this Application application, string folderName)
        {
            Directory.CreateDirectory(folderName);

            var result = new List<FileInfo>();
            result.AddRange(application.Tables.Select(t => t.WriteToFolder(folderName)));
            result.AddRange(application.Pages.Select(p => p.WriteToFolder(folderName)));
            result.AddRange(application.Reports.Select(r => r.WriteToFolder(folderName)));
            result.AddRange(application.Codeunits.Select(c => c.WriteToFolder(folderName)));
            result.AddRange(application.Queries.Select(q => q.WriteToFolder(folderName)));
            result.AddRange(application.XmlPorts.Select(x => x.WriteToFolder(folderName)));
            result.AddRange(application.MenuSuites.Select(m => m.WriteToFolder(folderName)));

            return result;
        }

        public static IEnumerable<FileInfo> WriteToFolder(this IEnumerable<Object> objects, string folderName)
        {
            Directory.CreateDirectory(folderName);

            var result = new List<FileInfo>();
            result.AddRange(objects.OfType<Table>().Select(t => t.WriteToFolder(folderName)));
            result.AddRange(objects.OfType<Page>().Select(p => p.WriteToFolder(folderName)));
            result.AddRange(objects.OfType<Report>().Select(r => r.WriteToFolder(folderName)));
            result.AddRange(objects.OfType<Codeunit>().Select(c => c.WriteToFolder(folderName)));
            result.AddRange(objects.OfType<Query>().Select(q => q.WriteToFolder(folderName)));
            result.AddRange(objects.OfType<XmlPort>().Select(x => x.WriteToFolder(folderName)));
            result.AddRange(objects.OfType<MenuSuite>().Select(m => m.Write(folderName)));

            return result;
        }

        public static FileInfo WriteToFolder(this Table table, string folderName)
        {
            return table.Write(Path.Combine(folderName, $"tab{table.ID}.txt"));
        }

        public static FileInfo WriteToFolder(this Page page, string folderName) => page.Write(Path.Combine(folderName, $"pag{page.ID}.txt"));

        public static FileInfo WriteToFolder(this Report report, string folderName) => report.Write(Path.Combine(folderName, $"rep{report.ID}.txt"));

        public static FileInfo WriteToFolder(this Codeunit codeunit, string folderName) => codeunit.Write(Path.Combine(folderName, $"cod{codeunit.ID}.txt"));

        public static FileInfo WriteToFolder(this Query query, string folderName) => query.Write(Path.Combine(folderName, $"que{query.ID}.txt"));

        public static FileInfo WriteToFolder(this XmlPort xmlPort, string folderName) => xmlPort.Write(Path.Combine(folderName, $"xml{xmlPort.ID}.txt"));

        public static FileInfo WriteToFolder(this MenuSuite menuSuite, string folderName) => menuSuite.Write(Path.Combine(folderName, $"men{menuSuite.ID}.txt"));
    }
}