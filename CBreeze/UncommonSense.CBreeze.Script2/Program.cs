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
                    "Table",
                    new SimpleParameter("ID", 50000, true),
                    new SimpleParameter("Name", "My Table", true),
                    new ScriptBlockParameter(
                        "SubObjects",
                        new Invocation("IntegerField",
                            new SimpleParameter("Name", "Entry No.", true)
                        )
                    )
                ).ToString()
            );
        }
    }
}