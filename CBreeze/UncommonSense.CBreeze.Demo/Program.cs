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
            var parserStopwatch = new Stopwatch();
            parserStopwatch.Start();
            var application = ApplicationBuilder.FromFile(@".\navw12015.txt");
            parserStopwatch.Stop();
            Console.WriteLine(parserStopwatch.Elapsed);

            var writerStopwatch = new Stopwatch();
            writerStopwatch.Start();
			application.Write(@"./ist.txt");
            writerStopwatch.Stop();
            Console.WriteLine(writerStopwatch.Elapsed);
		}
	}
}
