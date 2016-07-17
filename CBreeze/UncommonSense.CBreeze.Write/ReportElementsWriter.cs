using System;
using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class ReportElementsWriter
    {
        internal static string BuildReportElementPart(string value, int minLength, ref int debt)
        {
            var actualLength = value.Trim().Length;
            var idealLength = Math.Max(minLength - debt, 0);
            var length = Math.Max(actualLength, idealLength);

            debt += length - minLength;

            return value.PadRight(length);
        }

        public static void Write(this ReportElements reportElements, CSideWriter writer)
        {
            writer.BeginSection("DATASET");

            foreach (var reportElement in reportElements)
            {
                reportElement.Write(writer);
            }

            writer.EndSection();
        }

        public static void Write(this ReportElement reportElement, CSideWriter writer)
        {
            string type = null;

            TypeSwitch.Do(
                reportElement,
                TypeSwitch.Case<DataItemReportElement>(e => type = "DataItem"),
                TypeSwitch.Case<ColumnReportElement>(e => type = "Column"));

            var debt = 0;
            var elementID = BuildReportElementPart(reportElement.ID.ToString(), 4, ref debt);
            var elementIndentation = BuildReportElementPart(reportElement.IndentationLevel.AsString(), 4, ref debt);
            var elementType = BuildReportElementPart(type, 8, ref debt);
            var elementName = BuildReportElementPart(reportElement.Name, 20, ref debt);
            var declaration = string.Format("{{ {0};{1};{2};{3}", elementID, elementIndentation,elementType, elementName);

            writer.Write(declaration);
            writer.Indent(15);

            IEnumerable<Property> properties = null;

            TypeSwitch.Do(
                reportElement,
                TypeSwitch.Case<DataItemReportElement>(e => properties = e.Properties),
                TypeSwitch.Case<ColumnReportElement>(e => properties = e.Properties));

            var relevantProperties = properties.Where(p => p.HasValue);

            switch (relevantProperties.Any())
            {
                case true:
                    writer.WriteLine(";");
                    relevantProperties.Write(PropertiesStyle.Field, writer);
                    break;
                default:
                    writer.Write(" ");
                    break;
            }

            var lastProperty = relevantProperties.LastOrDefault();
            if (lastProperty != null)
                if (lastProperty is TriggerProperty)
                    writer.Write(new string(' ', lastProperty.Name.Length + 2));

            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }
    }
}

