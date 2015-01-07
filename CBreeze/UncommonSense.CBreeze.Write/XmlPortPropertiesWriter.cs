using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class XmlPortPropertiesWriter
    {
        public static void Write(this XmlPortProperties xmlPortProperties, CSideWriter writer)
        {
            writer.BeginSection("PROPERTIES");

            var relevantProperties = xmlPortProperties.Where(p => p.HasValue);

            foreach (Property property in relevantProperties)
            {
                // For XmlPorts, even the last relevant property ends with a semicolon
                property.Write(false, PropertiesStyle.Object, writer);
            }

            writer.EndSection();
        }
    }
}
