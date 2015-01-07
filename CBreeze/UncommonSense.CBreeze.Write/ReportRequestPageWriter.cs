using System;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class ReportRequestPageWriter
	{
		public static void Write(this ReportRequestPage reportRequestPage, CSideWriter writer)
		{
			writer.BeginSection("REQUESTPAGE");
			reportRequestPage.Properties.Write(PropertiesStyle.Object, writer);
			reportRequestPage.Controls.Write(writer, 18);
			writer.EndSection();
		}
	}
}

