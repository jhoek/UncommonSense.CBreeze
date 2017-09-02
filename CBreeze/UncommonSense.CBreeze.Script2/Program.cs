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
                    new SimpleParameter("ID", 50000, true, true),
                    new SimpleParameter("Name", "'My Table'", true, true),
                    new ScriptBlockParameter(
                        "SubObjects",
                        new Invocation("IntegerField",
                            new SimpleParameter("Name", "'Entry No.'", true)
                        ),
                        new Invocation("Procedure",
                            new SimpleParameter("Name", "MyFunction", true),
                            new ScriptBlockParameter("SubObjects",
                                new Literal("// Code goes here")
                            )
                        )
                    )
                ).ToString()
            );
        }
    }
}