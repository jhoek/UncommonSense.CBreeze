using System;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
	public static class ReportLabelsWriter
	{
		public static void Write(this ReportLabels reportLabels, CSideWriter writer)
		{
			writer.BeginSection("LABELS");

			foreach (var reportLabel in reportLabels) 
			{
				reportLabel.Write(writer);
			}

			writer.EndSection();
		}

		public static void Write(this ReportLabel reportLabel, CSideWriter writer)
		{
            var id = reportLabel.ID.ToString().PadRight(4);
            var name = reportLabel.Name.PadRight(20);

            writer.Write("{ ");
            writer.Write(id);
            writer.Write(";");
            writer.Write(name);

            var relevantProperties = reportLabel.Properties.Where(p => p.HasValue);

            switch (relevantProperties.Any())
            {
                case true:
                    writer.Write(";");
                    break;
                default:
                    writer.Write(" ");
                    break;
            }

            if (writer.Column > 32)
            {
                writer.Indent(32);
                writer.WriteLine("");
        }
            else
            {
                writer.Indent(writer.Column);
            }

            reportLabel.Properties.Write(PropertiesStyle.Field, writer);

            writer.WriteLine("}");
            writer.Unindent();
		} 
	}
}

