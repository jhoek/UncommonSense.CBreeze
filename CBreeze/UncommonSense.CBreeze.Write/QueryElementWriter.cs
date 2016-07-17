using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class QueryElementWriter
    {
        public static void Write(this QueryElement element, CSideWriter writer)
        {
            TypeSwitch.Do(
                element,
                TypeSwitch.Case<DataItemQueryElement>(e => e.Write(writer)),
                TypeSwitch.Case<ColumnQueryElement>(e => e.Write(writer)),
                TypeSwitch.Case<FilterQueryElement>(e => e.Write(writer))
                );
        }

        public static void Write(this DataItemQueryElement element, CSideWriter writer)
        {
            WriteDeclaration(element.ID, element.IndentationLevel, "DataItem", element.Name,writer);
            element.Properties.Where(p => p.HasValue).Write(PropertiesStyle.Field, writer);
            writer.WriteLine("}");
            writer.Unindent();
            writer.InnerWriter.WriteLine();
        }

        public static void Write(this ColumnQueryElement element,CSideWriter writer)
        {
            WriteDeclaration(element.ID, element.IndentationLevel, "Column", element.Name,writer);
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

        private static void WriteDeclaration(int id, int? indentation, string type, string name, CSideWriter writer)
        {
            name = name ?? string.Empty;
            var nameLength = Math.Max(name.Length, 20);

            writer.Write("{ ");
            writer.Write(id.ToString().PadRight(4));
            writer.Write(";");
            writer.Write((indentation.HasValue ? indentation.Value.ToString() : string.Empty).PadRight(4));
            writer.Indent(writer.Column);
            writer.Write(";");
            writer.Write(type.PadRight(8));
            writer.Write(";");
            writer.Write(name.PadRight(nameLength));
            writer.WriteLine(";");
        }
    }
}
