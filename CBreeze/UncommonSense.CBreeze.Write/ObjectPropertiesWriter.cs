using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class ObjectPropertiesWriter
	{
		public static void Write(this ObjectProperties objectProperties, CSideWriter writer)
		{
			writer.BeginSection("OBJECT-PROPERTIES");
            writer.WriteLineIf(objectProperties.DateTime.HasValue, "Date={0};", objectProperties.DateTime.ToShortDateString());
            writer.WriteLineIf(objectProperties.DateTime.HasValue, "Time={0};", objectProperties.DateTime.ToShortTimeString());
            writer.WriteLineIf(objectProperties.Modified, "Modified=Yes;");
            writer.WriteLineIf(objectProperties.VersionList != null, "Version List={0};", objectProperties.VersionList); 
			writer.EndSection();
		}
	}
}
