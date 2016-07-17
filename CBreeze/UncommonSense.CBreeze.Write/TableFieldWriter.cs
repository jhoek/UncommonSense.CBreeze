using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

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
            IEnumerable<Property> properties = null;

            TypeSwitch.Do(
                field,
                TypeSwitch.Case<BigIntegerTableField>(f => properties = f.Properties),
                TypeSwitch.Case<BinaryTableField>(f => properties = f.Properties),
                TypeSwitch.Case<BlobTableField>(f => properties = f.Properties),
                TypeSwitch.Case<BooleanTableField>(f => properties = f.Properties),
                TypeSwitch.Case<CodeTableField>(f => properties = f.Properties),
                TypeSwitch.Case<DateTableField>(f => properties = f.Properties),
                TypeSwitch.Case<DateFormulaTableField>(f => properties = f.Properties),
                TypeSwitch.Case<DateTimeTableField>(f => properties = f.Properties),
                TypeSwitch.Case<DecimalTableField>(f => properties = f.Properties),
                TypeSwitch.Case<DurationTableField>(f => properties = f.Properties),
                TypeSwitch.Case<GuidTableField>(f => properties = f.Properties),
                TypeSwitch.Case<IntegerTableField>(f => properties = f.Properties),
                TypeSwitch.Case<OptionTableField>(f => properties = f.Properties),
                TypeSwitch.Case<RecordIDTableField>(f => properties = f.Properties),
                TypeSwitch.Case<TableFilterTableField>(f => properties = f.Properties),
                TypeSwitch.Case<TextTableField>(f => properties = f.Properties),
                TypeSwitch.Case<TimeTableField>(f => properties = f.Properties));

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
            string result = null;

            TypeSwitch.Do(
                field,
                TypeSwitch.Case<BigIntegerTableField>(f => result = "BigInteger"),
                TypeSwitch.Case<BinaryTableField>(f => result = string.Format("Binary{0}", f.DataLength)),
                TypeSwitch.Case<BlobTableField>(f => result = "BLOB"),
                TypeSwitch.Case<BooleanTableField>(f => result = "Boolean"),
                TypeSwitch.Case<CodeTableField>(f => result = string.Format("Code{0}", f.DataLength)),
                TypeSwitch.Case<DateTableField>(f => result = "Date"),
                TypeSwitch.Case<DateFormulaTableField>(f => result = "DateFormula"),
                TypeSwitch.Case<DateTimeTableField>(f => result = "DateTime"),
                TypeSwitch.Case<DecimalTableField>(f => result = "Decimal"),
                TypeSwitch.Case<DurationTableField>(f => result = "Duration"),
                TypeSwitch.Case<GuidTableField>(f => result = "GUID"),
                TypeSwitch.Case<IntegerTableField>(f => result = "Integer"),
                TypeSwitch.Case<OptionTableField>(f => result = "Option"),
                TypeSwitch.Case<RecordIDTableField>(f => result = "RecordID"),
                TypeSwitch.Case<TableFilterTableField>(f => result = "TableFilter"),
                TypeSwitch.Case<TextTableField>(f => result = string.Format("Text{0}", f.DataLength)),
                TypeSwitch.Case<TimeTableField>(f => result = "Time"));

            return result;
        }
    }
}
