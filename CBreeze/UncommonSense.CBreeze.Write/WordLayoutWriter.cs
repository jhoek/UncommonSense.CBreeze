using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Write
{
#if NAV2015
    public static class WordLayoutWriter
    {
        public static void Write(this WordLayout wordLayout, CSideWriter writer)
        {
            if (wordLayout.CodeLines.Any())
            {
                writer.BeginSection("WORDLAYOUT");

                foreach (var line in wordLayout.CodeLines)
                {
                    writer.WriteLine(line);
                }

                writer.InnerWriter.WriteLine("    END_OF_WORDLAYOUT");

                writer.EndSection();
            }
        }
    }
#endif
}
