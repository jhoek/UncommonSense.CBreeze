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
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            DefaultRanges.ID = Enumerable.Range(50000, 1000);
            DefaultRanges.UID = Enumerable.Range(1000000000, 1000);

            var application = new Application();
            var page = application.Pages.Add(new Page("Foo"));

            page.Controls.Add(new ContainerPageControl(0, 0, ContainerType.ContentArea));
            page.Controls.Add(new GroupPageControl(0, 1, GroupType.Repeater));

            var function = page.Code.Functions.Add(new Function(0, "Foo"));
            function.Parameters.Add(new IntegerParameter(false, 0, "MyParam"));
            function.Parameters.Add(new BigTextParameter(false, 0, "MyBigText"));
            function.Variables.Add(new IntegerVariable(0, "Oink"));
            function.Variables.Add(new IntegerVariable(0, "Boink"));

            var function2 = page.Code.Functions.Add(new Function(0, "Baz"));

            application.Write();
        }
    }
}