using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Write
{
    public static class ReportWriter
    {
        public static void Write(this Report report, CSideWriter writer)
        {
            writer.BeginSection(report.GetObjectSignature());
			report.ObjectProperties.Write(writer);
			report.Properties.Write(writer);
			report.Elements.Write(writer);
			report.RequestPage.Write(writer);
			report.Labels.Write(writer);
			report.Code.Write(writer);
            report.RdlData.Write(writer);
#if NAV2015
            report.WordLayout.Write(writer);
#endif
            writer.EndSection();
			writer.InnerWriter.WriteLine();
        }
    }
}
