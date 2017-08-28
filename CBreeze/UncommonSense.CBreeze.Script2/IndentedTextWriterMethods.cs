using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script2
{
    public static class IndentedTextWriterMethods
    {
        public static void WriteIf(this IndentedTextWriter writer, bool condition, object value)
        {
            if (condition)
            {
                writer.Write(value);
            }
        }

        public static void WriteLineIf(this IndentedTextWriter writer, bool condition, object value)
        {
            if (condition)
            {
                writer.WriteLine(value);
            }
        }
    }
}