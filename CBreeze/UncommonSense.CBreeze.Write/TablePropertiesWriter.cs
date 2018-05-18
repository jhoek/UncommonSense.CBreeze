using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Table;

namespace UncommonSense.CBreeze.Write
{
	public static class TablePropertiesWriter
	{
		public static void Write(this TableProperties tableProperties, CSideWriter writer)
		{
			writer.BeginSection("PROPERTIES");

            var relevantProperties = tableProperties.Where(p => p.HasValue);

            foreach (Property property in relevantProperties)
            {
                var isLastProperty = (property == relevantProperties.Last());
                property.Write(isLastProperty, PropertiesStyle.Object, writer);
            }

			writer.EndSection();
		}
	}
}
