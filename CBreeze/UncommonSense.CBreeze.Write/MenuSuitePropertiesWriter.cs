using System;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.MenuSuite;

namespace UncommonSense.CBreeze.Write
{
	public static class MenuSuitePropertiesWriter
	{
		public static void Write(this MenuSuiteProperties menusuiteProperties, CSideWriter writer)
		{
			writer.BeginSection("PROPERTIES");
			writer.EndSection();
		}
	}
}

