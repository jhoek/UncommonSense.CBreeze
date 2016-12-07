using System;
using System.Linq;
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
            var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var applications = new string[] { "be" };

            foreach (var application in applications)
            {
                var inputFolderName = Path.Combine(desktopFolderName, application);
                var outputFolderName = Path.Combine(desktopFolderName, $"{application}.output");

                Directory.CreateDirectory(outputFolderName);

                foreach (var filePath in Directory.GetFiles(inputFolderName, "*.TXT"))
                {
                    var fileName = Path.GetFileName(filePath);
                    Console.WriteLine(fileName);

                    var inputPath = Path.Combine(inputFolderName, fileName);
                    var outputPath = Path.Combine(outputFolderName, fileName);

                    ApplicationBuilder.FromFile(inputPath).Write(outputPath);
                }
            }
        }
    }
}
