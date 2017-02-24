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
            var range = Enumerable.Range(50000, 100);
            var application = new Application();
            var page = application.Pages.Add(new Page(0, "Foo"));

            page.ObjectProperties.DateTime = DateTime.Now;
            page.ObjectProperties.Modified = true;

            page.Controls.Add(new ContainerPageControl(0, 0, ContainerType.ContentArea));
            page.Controls.Add(new GroupPageControl(0, 1, GroupType.Repeater));
            page.Controls.Add(new FieldPageControl(0, 2, "Foo"));

            application.Write(Console.Out);
        }
    }
}
