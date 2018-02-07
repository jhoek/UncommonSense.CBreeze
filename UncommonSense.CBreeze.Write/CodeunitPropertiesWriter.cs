using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class CodeunitPropertiesWriter
	{
		public static void Write(this CodeunitProperties codeunitProperties, CSideWriter writer)
		{
			writer.BeginSection("PROPERTIES");

            var relevantProperties = codeunitProperties.Where(p => p.HasValue || p is TriggerProperty);

            foreach (Property property in relevantProperties)
            {
                var isLastProperty = (property == relevantProperties.Last());
                property.Write(isLastProperty, PropertiesStyle.Object, writer);
            }

			writer.EndSection();
		}
	}
}
