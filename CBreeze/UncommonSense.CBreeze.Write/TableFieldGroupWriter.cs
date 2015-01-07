using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class TableFieldGroupWriter
    {
        public static void Write(this TableFieldGroup fieldGroup, CSideWriter writer)
        {
            var fields = string.Join(",", fieldGroup.Fields.Select(f=>f.FieldName));
            var fieldsWidth = Math.Max(fields.Length, 40);

            writer.Write("{ ");
            writer.Write(fieldGroup.ID.ToString().PadRight(4));
            writer.Write(";");
            writer.Write(fieldGroup.Name.PadRight(20));
            writer.Write(";");
            writer.Write(fields.PadRight(fieldsWidth));

            if (fieldGroup.Properties.Any(p => p.HasValue))
            {
                writer.Write(";");
                writer.Indent(writer.Column);
                fieldGroup.Properties.Write(PropertiesStyle.Field, writer);
                writer.Unindent();
            }
            else
            {
                writer.Write(" ");
            }

            writer.WriteLine("}");
        }
    }
}
