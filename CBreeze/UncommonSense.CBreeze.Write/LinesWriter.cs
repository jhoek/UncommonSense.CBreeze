using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class LinesWriter
    {
        public static void Write(this CodeLines codeLines, CSideWriter writer)
        {
            foreach (var codeLine in codeLines)
            {
                if (string.IsNullOrEmpty(codeLine))
                    writer.InnerWriter.WriteLine();
                else
                    writer.WriteLine(codeLine);
            }
        }
    }
}
