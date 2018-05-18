using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Table.Field;

namespace UncommonSense.CBreeze.Write
{
    public static class TableFieldWriter
    {
        internal static string BuildFieldPart(string value, int minLength, ref int debt)
        {
            var actualLength = value.Trim().Length;
            var idealLength = Math.Max(minLength - debt, 0);
            var length = Math.Max(actualLength, idealLength);

            debt += length - minLength;

            return value.PadRight(length);
        }

        public static void Write(this TableField field, CSideWriter writer)
        {
            var debt = 0;

            var fieldNo = BuildFieldPart(field.ID.ToString(), 4, ref debt);
            var fieldEnabled = BuildFieldPart(field.Enabled.AsString(), 3, ref debt);
            var fieldName = BuildFieldPart(field.Name, 20, ref debt);
            var fieldTypeName = BuildFieldPart(field.TypeName(), 14, ref debt);
            var declaration = string.Format("{{ {0};{1};{2};{3}", fieldNo, fieldEnabled, fieldName, fieldTypeName);
            var properties = field.AllProperties;

            writer.Write("{0}", declaration.PadRight(46));
            writer.Write(properties.Any(p => p.HasValue) ? ";" : " ");

            if (writer.Column > 51)
            {
                writer.Indent(51);
                writer.WriteLine("");
            }
            else
            {
                writer.Indent(writer.Column);
            }

            properties.Write(PropertiesStyle.Field, writer);

            var relevantProperties = properties.Where(p => p.HasValue);
            var lastProperty = relevantProperties.LastOrDefault();
            if (lastProperty != null)
                if (lastProperty is TriggerProperty)
                    writer.Write(new string(' ', lastProperty.Name.Length + 2));

            writer.WriteLine("}");
            writer.Unindent();
        }

        private static string TypeName(this TableField field)
        {
            switch (field)
            {
                case BinaryTableField binaryTableField: return $"Binary{binaryTableField.DataLength}";
                case CodeTableField codeTableField: return $"Code{codeTableField.DataLength}";
                case GuidTableField guidTableField: return "GUID";
                case TextTableField textTableField: return $"Text{textTableField.DataLength}";
                default: return field.Type.ToString();
            }
        }
    }
}
