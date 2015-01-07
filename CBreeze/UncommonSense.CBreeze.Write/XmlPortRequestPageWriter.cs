using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class XmlPortRequestPageWriter
    {
        public static void Write(this XmlPortRequestPage xmlPortRequestPage, CSideWriter writer)
        {
            writer.BeginSection("REQUESTPAGE");
            xmlPortRequestPage.Properties.Write(writer);
            xmlPortRequestPage.Controls.Write(writer, 16);
            writer.EndSection();
        }
    }
}
