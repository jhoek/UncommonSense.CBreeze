using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Write
{
    public static class SectionExtensionMethods
    {
        public static CSideWriter BeginSection(this CSideWriter writer, string sectionName)
        {
            writer.WriteLine(sectionName);
            writer.WriteLine("{");
            writer.Indent();

            return writer;
        }

        public static CSideWriter EndSection(this CSideWriter writer)
        {
            writer.Unindent();
            writer.WriteLine("}");

            return writer;
        }
   }
}
