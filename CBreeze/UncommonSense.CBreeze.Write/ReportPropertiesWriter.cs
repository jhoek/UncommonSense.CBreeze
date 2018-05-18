using System;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class ReportPropertiesWriter
	{
		public static void Write(this ReportProperties reportProperties, CSideWriter writer){
			writer.BeginSection("PROPERTIES");

			var relevantProperties = reportProperties.Where(p => p.HasValue);

			foreach (Property property in relevantProperties) {
                // The object text format for reports in NAV 2013 does not seem to
                // differentiate between the last property, and the ones preceding it.
                // I like the simplicity, but dislike the inconsistency... ;)
                var isLastProperty = false; // (property == relevantProperties.Last());
				property.Write(isLastProperty, PropertiesStyle.Field, writer);
			}

			writer.EndSection();
		}
	}
}

