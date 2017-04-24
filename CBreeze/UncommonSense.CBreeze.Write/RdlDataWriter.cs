using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class RdlDataWriter
    {
        public static void Write(this RdlData rdlData, CSideWriter writer)
        {
            writer.BeginSection("RDLDATA");

            if (rdlData.CodeLines.Any())
            {
                foreach (var line in rdlData.CodeLines)
                {
                    writer.InnerWriter.WriteLine(line);
                }

                writer.InnerWriter.WriteLine("    END_OF_RDLDATA");
            }

            writer.EndSection();
        }
    }
}
