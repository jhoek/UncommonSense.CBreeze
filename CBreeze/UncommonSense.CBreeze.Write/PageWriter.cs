using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class PageWriter
    {
        public static void Write(this Page page, CSideWriter writer)
        {
            writer.BeginSection(page.GetObjectSignature());
            page.ObjectProperties.Write(writer);
            page.Properties.Write(writer);
            page.Controls.Write(writer, 16);
            page.Code.Write(writer);
            writer.EndSection();
            writer.InnerWriter.WriteLine();
        }
    }
}
