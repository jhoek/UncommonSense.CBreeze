using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Parse.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var myListener = new MyListener();
            var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var sourceFolderName = Path.Combine(desktopFolderName, "be");

            var parser = new Parser();
            parser.Listener = myListener;
            parser.ParseFiles(Directory.GetFiles(sourceFolderName, "*.txt"));
        }
    }
}
