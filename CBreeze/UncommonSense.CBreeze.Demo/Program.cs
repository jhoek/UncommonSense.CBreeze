using System;
using System.Diagnostics;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;
using UncommonSense.CBreeze.Read;
using System.IO;
using System.Text;

namespace UncommonSense.CBreeze.Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var compareToolFileName = @"c:\Program Files\Araxis\Araxis Merge\compare.exe";

            var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var inputFileName = Path.Combine(desktopFolderName, "nav2016.txt");
            var outputFileName = Path.Combine(desktopFolderName, "nav2016.output.txt");

            var readerStopWatch = new Stopwatch();
            readerStopWatch.Start();
            var lines = File.ReadLines(inputFileName, Encoding.GetEncoding("ibm850"));
            readerStopWatch.Stop();
            Console.WriteLine("Reading took {0} ms.", readerStopWatch.ElapsedMilliseconds);

            var parserStopwatch = new Stopwatch();
            parserStopwatch.Start();
            var application = ApplicationBuilder.FromLines(lines);
            parserStopwatch.Stop();
            Console.WriteLine("Parsing took {0} ms.", parserStopwatch.ElapsedMilliseconds);

            var writerStopwatch = new Stopwatch();
            writerStopwatch.Start();
            application.Write(outputFileName);
            writerStopwatch.Stop();
            Console.WriteLine("Writing took {0} ms.", writerStopwatch.ElapsedMilliseconds);

            Process.Start(compareToolFileName, string.Format("\"{0}\" \"{1}\"", inputFileName, outputFileName));
        }
    }
}
