using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class RequestPageWriter
    {
        public static void Write(this RequestPage requestPage, CSideWriter writer)
        {
            writer.BeginSection("REQUESTPAGE");
            requestPage.Properties.Write(PropertiesStyle.Object, writer);

#if NAV2017
            requestPage.Controls.Write(writer, 18);
#else
             requestPage.Controls.Write(writer, 16);
#endif
            writer.EndSection();
        }
    }
}
