using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class PagePropertiesWriter
    {
        public static void Write(this PageProperties pageProperties, CSideWriter writer)
        {
            writer.BeginSection("PROPERTIES");

            var relevantProperties = pageProperties.Where(p => p.HasValue);

            foreach (var property in relevantProperties)
            {
                var isLastProperty = (property == relevantProperties.Last());
                property.Write(isLastProperty, PropertiesStyle.Object, writer);
            }

            writer.EndSection();
        }
    }
}
