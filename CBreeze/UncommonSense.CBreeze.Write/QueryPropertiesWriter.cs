using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Write
{
    public static class QueryPropertiesWriter
    {
        public static void Write(this QueryProperties queryProperties, CSideWriter writer)
        {
            writer.BeginSection("PROPERTIES");

            var relevantProperties = queryProperties.Where(p => p.HasValue);

            foreach (Property property in relevantProperties)
            {
                var isLastProperty = (property == relevantProperties.Last());
                property.Write(isLastProperty, PropertiesStyle.Object, writer);
            }

            writer.EndSection();
        }
    }
}
