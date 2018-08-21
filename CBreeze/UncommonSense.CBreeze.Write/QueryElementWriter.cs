using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class LinePartWriter
    {
        public static void WriteLineParts(this CSideWriter writer, params LinePart[] parts)
        {
            var debt = 0;

            foreach (var part in parts)
            {
                var value = part.Elastic ? part.Value.PadRight(Math.Max(0, part.NominalWidth - debt)) : part.Value;
                if (part.NewLine) { writer.WriteLine(value); } else { writer.Write(value); }
                if (part.SetIndentationAt != 0) { writer.Indent(part.SetIndentationAt); }
                debt = debt + (value.Length - part.NominalWidth);
            }
        }
    }

    public static class QueryElementWriter
    {
        private static void WriteDeclaration(int id, int? indentation, string type, string name, CSideWriter writer)
        {
            writer.WriteLineParts(
                new LinePart("{ ", 2, false),
                new LinePart(id.ToString(), 4, true),
                new LinePart(";", 1, false),
                new LinePart(indentation.HasValue ? indentation.Value.ToString() : string.Empty, 4, true) { SetIndentationAt = 15 },
                new LinePart(";", 1, false),
                new LinePart(type, 8, true),
                new LinePart(";", 1, false),
                new LinePart(name ?? string.Empty, 20, true),
                new LinePart(";", 1, false) { NewLine = true }
            );

            //var idText = id.ToString().PadRight(4);
            //var debt = idText.Length > 4 ? idText.Length - 4 : 0;
            //var indentationText = (indentation.HasValue ? indentation.Value.ToString() : string.Empty).PadRight(Math.Max(4 - debt, 0));
            //debt = debt - Math.Max(indentationText.Length - 2, 0);

            //name = name ?? string.Empty;
            //var nameLength = Math.Max(name.Length, 20);

            //writer.Write("{ ");
            //writer.Write(idText);
            //writer.Write(";");
            //writer.Write(indentationText);
            //writer.Indent(writer.Column);
            //writer.Write(";");
            //writer.Write(type.PadRight(8 - debt));
            //writer.Write(";");
            //writer.Write(name.PadRight(nameLength - debt));
            //writer.WriteLine(";");
        }

        public static void Write(this QueryElement element, CSideWriter writer)
        {
            switch (element)
            {
                case DataItemQueryElement d: d.Write(writer); break;
                case ColumnQueryElement c: c.Write(writer); break;
                case FilterQueryElement f: f.Write(writer); break;
            }
        }

        public static void Write(this DataItemQueryElement element, CSideWriter writer)
        {
            WriteDeclaration(element.ID, element.IndentationLevel, "DataItem", element.Name, writer);
            element.Properties.Where(p => p.HasValue).Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this ColumnQueryElement element, CSideWriter writer)
        {
            WriteDeclaration(element.ID, element.IndentationLevel, "Column", element.Name, writer);
            element.Properties.Where(p => p.HasValue).Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this FilterQueryElement element, CSideWriter writer)
        {
            WriteDeclaration(element.ID, element.IndentationLevel, "Filter", element.Name, writer);
            element.Properties.Where(p => p.HasValue).Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }
    }

    // FIXME: generic API for writing lines from elements using "debts"; use everywhere where applicable
    // FIXME: make separate classes for fixed and elastic line parts
    public class LinePart
    {
        public LinePart(string value, int nominalWidth, bool elastic)
        {
            Value = value;
            NominalWidth = nominalWidth;
            Elastic = elastic;
        }

        public bool Elastic { get; }
        public bool NewLine { get; set; }
        public int NominalWidth { get; }
        public int SetIndentationAt { get; set; }
        public string Value { get; }
    }
}