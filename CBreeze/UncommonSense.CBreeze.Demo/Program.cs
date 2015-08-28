using System;
using System.Diagnostics;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;
using UncommonSense.CBreeze.Read;
using System.IO;

namespace UncommonSense.CBreeze.Demo
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var programsFolderName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			var compareToolFileName = Path.Combine(programsFolderName, "Araxis Merge.app");

			var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var inputFileName = Path.Combine(desktopFolderName, "nl2013.txt");
			var outputFileName = Path.Combine(desktopFolderName, "nl2013.output.txt");

			var parserStopwatch = new Stopwatch();
			parserStopwatch.Start();
			var application = ApplicationBuilder.FromFile(inputFileName);
			parserStopwatch.Stop();
			Console.WriteLine(parserStopwatch.Elapsed);

			var writerStopwatch = new Stopwatch();
			writerStopwatch.Start();
			application.Write(outputFileName);
			writerStopwatch.Stop();
			Console.WriteLine(writerStopwatch.Elapsed);

			Process.Start(compareToolFileName, string.Format("\"{0}\" \"{1}\"", inputFileName, outputFileName));
		}
	}
}
