using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ApplicationBuilder
                .FromFolder(@"C:\Users\jhoek\Dropbox\BaseAppExports\w12017")
                .WriteToFolder(@"c:\users\jhoek\Desktop\output");
        }
    }
}