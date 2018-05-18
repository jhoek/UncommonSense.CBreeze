using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Variable;

namespace UncommonSense.CBreeze.Write
{
    public static class VariablesWriter
    {
        public static void Write(this Variables variables, CSideWriter writer)
        {
            if (!variables.Any())
                return;

            writer.WriteLine("VAR");
            writer.Indent();

            foreach (Variable variable in variables)
            {
                variable.Write(writer);
            }

            writer.Unindent();
        }
    }
}
