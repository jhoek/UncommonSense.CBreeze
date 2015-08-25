using System;
using System.Diagnostics;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var commandLine = new CommandLine(args);

            var parserStopwatch = new Stopwatch();
            parserStopwatch.Start();
            var application = ApplicationBuilder.FromFile(commandLine.InputFileName);
            parserStopwatch.Stop();
            Console.WriteLine(parserStopwatch.Elapsed);

            var writerStopwatch = new Stopwatch();
            writerStopwatch.Start();
            application.Write(commandLine.OutputFileName);
            writerStopwatch.Stop();
            Console.WriteLine(writerStopwatch.Elapsed);

            Process.Start(commandLine.CompareToolFileName, string.Format("\"{0}\" \"{1}\"", commandLine.InputFileName, commandLine.OutputFileName));
        }
    }
}
