using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tagList = new TagList();
            //tagList.Add("#Foo");
            //tagList.Add("#Baz");
            //Console.WriteLine(tagList);

            var application = ApplicationBuilder.FromFile(@"c:\users\jhoek\Dropbox\BaseAppExports\w12017.txt");
        }
    }
}
