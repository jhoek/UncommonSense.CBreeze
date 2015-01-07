using System;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class ReportRequestPagePropertiesWriter
	{
		public static void Write (this ReportRequestPageProperties reportRequestPageProperties, PropertiesStyle style, CSideWriter writer) 
		{
			writer.BeginSection("PROPERTIES");

			var relevantProperties = reportRequestPageProperties.Where(p=>p.HasValue);

			relevantProperties.Write(style, writer);

			writer.EndSection();
		}
	}
}

