using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Invocation(
                "Table",
                new SimpleParameter("ID", 15) { OnCmdletLine = true, Positional = true },
                new SimpleParameter("Name", "My Table") { OnCmdletLine = true, Positional = true },
                new SwitchParameter("Modified", true) { OnCmdletLine = true },
                new ScriptBlockParameter("SubObjects",
                    new Invocation("Procedure",
                    new SimpleParameter("ID", 1000) { OnCmdletLine = true, Positional = true },
                    new SimpleParameter("Name", "My Procedure") { OnCmdletLine = true, Positional = true },
                    new ScriptBlockParameter("SubObjects",
                        new Invocation("BooleanVariable")
                    )
                ))
                { Positional = true, OnCmdletLine = true })
                .WriteTo(new ScriptWriter(Console.Out));
        }
    }
}