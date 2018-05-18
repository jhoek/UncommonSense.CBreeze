using System;
using System.Linq;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Write
{
	public static class RequestPagePropertiesWriter
	{
		public static void Write (this RequestPageProperties properties, PropertiesStyle style, CSideWriter writer) 
		{
			writer.BeginSection("PROPERTIES");
			properties.AsEnumerable().Write(style, writer);
			writer.EndSection();
		}
	}
}

