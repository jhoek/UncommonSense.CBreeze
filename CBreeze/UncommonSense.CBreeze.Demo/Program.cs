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
            var application = new Application()
            {
                IDRange = Enumerable.Range(50000, 1000),
                UIDRange = Enumerable.Range(1000000000, 1000)
            };

            application.Pages.Range = application.IDRange;
            var page = application.Pages.Add(new Page(0, "Foo"));

            page.ObjectProperties.DateTime = DateTime.Now;
            page.ObjectProperties.Modified = true;

            page.Controls.Range = application.UIDRange;
            page.Controls.Add(new ContainerPageControl(0, 0, ContainerType.ContentArea));
            page.Controls.Add(new GroupPageControl(0, 1, GroupType.Repeater));
            page.Controls.Add(new FieldPageControl(0, 2, "Foo"));

            application.Write(Console.Out);
        }
    }
}
