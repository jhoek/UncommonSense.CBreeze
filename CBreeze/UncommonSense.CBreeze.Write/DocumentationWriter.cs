using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code;

namespace UncommonSense.CBreeze.Write
{
    public static class DocumentationWriter
    {
        public static void Write(this Documentation documentation, CSideWriter writer)
        {
            writer.InnerWriter.WriteLine();
            writer.WriteLine("BEGIN");

            if (documentation.CodeLines.Any())
            {
                writer.WriteLine("{");
                writer.Indent();
                documentation.CodeLines.Write(writer);
                writer.Unindent();
                writer.WriteLine("}");
            }

            writer.WriteLine("END.");
        }
    }
}
