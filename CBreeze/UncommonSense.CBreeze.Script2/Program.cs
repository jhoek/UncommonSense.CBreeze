using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(
                new Invocation(
                    "New-Foo",
                    new SimpleParameter("Foo", "Baz") { Positional = true }).ToString());
        }
    }
}