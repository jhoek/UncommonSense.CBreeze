using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class PropertiesWriter
    {
        public static void Write(this IEnumerable<Property> properties, PropertiesStyle style, CSideWriter writer)
        {
            var relevantProperties = properties.Where(p => p.HasValue);

            foreach (var property in relevantProperties)
            {
                var isLastProperty = (property == relevantProperties.Last());
                property.Write(isLastProperty, style, writer);
            }
        }
    }
}
