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
                .ReadFromFolder(@"C:\Users\jhoek\GitHub\Dynamics.NAV.ReferenceObjects.2017\NL\RTM")
                .WriteToFolder(@"c:\users\jhoek\Desktop\NL2017RTM");
        }
    }
}