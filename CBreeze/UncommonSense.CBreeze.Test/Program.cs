using System;
using System.Collections.Generic;
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
                .FromFile(@"c:\users\jhoek\Dropbox\BaseAppExports\w12017.txt")
                .Write(@"c:\users\jhoek\Desktop\output.txt");
        }
    }
}