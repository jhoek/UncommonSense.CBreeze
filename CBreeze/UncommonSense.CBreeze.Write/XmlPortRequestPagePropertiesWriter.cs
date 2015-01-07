using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class XmlPortRequestPagePropertiesWriter
    {
        public static void Write(this XmlPortRequestPageProperties properties, CSideWriter writer)
        {
            writer.BeginSection("PROPERTIES");
			properties.Write(PropertiesStyle.Object, writer);
			writer.EndSection();
        }
    }
}
