using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class Formatters
    {
        public static string AsString(this TextEncoding value)
        {
            switch (value)
            {
                case TextEncoding.MsDos:
                    return "MS-DOS";
                case TextEncoding.Utf8:
                    return "UTF-8";
                case TextEncoding.Utf16:
                    return "UTF-16";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string[] AsStrings(this TableFilter value)
        {
            var lines = new List<string>();

            for (int i = 0; i < value.Count(); i++)
            {
                var isFirstLine = (i == 0);
                var isLastLine = (i == value.Count() - 1);
                var tableFilterLine = value.ElementAt(i);
                var line = string.Format("{0}={1}({2})", tableFilterLine.FieldName, tableFilterLine.Type.Value.AsString(), tableFilterLine.Value);

                if (isFirstLine)
                    line = string.Format("WHERE({0}", line);
                else
                    line = string.Format("      {0}", line);

                if (isLastLine)
                    line = string.Format("{0})", line);
                else
                    line = string.Format("{0},", line);

                lines.Add(line);
            }

            return lines.ToArray<string>();
        }

        public static string AsString(this StandardDayTimeUnit value)
        {
            switch (value)
            {
                case StandardDayTimeUnit.Day:
                    return "day";
                case StandardDayTimeUnit.Hour:
                    return "hour";
                case StandardDayTimeUnit.Minute:
                    return "minute";
                case StandardDayTimeUnit.Second:
                    return "second";
                case StandardDayTimeUnit.Millisecond:
                    return "millisecond";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this TableRelationConditionType conditionType)
        {
            switch (conditionType)
            {
                case TableRelationConditionType.Const:
                    return "CONST";
                case TableRelationConditionType.Filter:
                    return "FILTER";
                default:
                    throw new ArgumentOutOfRangeException("conditionType");
            }
        }

        public static string AsString(this RunObjectLinkLineType type)
        {
            switch (type)
            {
                case RunObjectLinkLineType.Const:
                    return "CONST";
                case RunObjectLinkLineType.Filter:
                    return "FILTER";
                case RunObjectLinkLineType.Field:
                    return "FIELD";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public static string AsString(this TableFilterType type)
        {
            switch (type)
            {
                case TableFilterType.Const:
                    return "CONST";
                case TableFilterType.Filter:
                    return "FILTER";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public static string AsString(this ExtendedTableFilterType type)
        {
            switch (type)
            {
                case ExtendedTableFilterType.Const:
                    return "CONST";
                case ExtendedTableFilterType.Field:
                    return "FIELD";
                case ExtendedTableFilterType.Filter:
                    return "FILTER";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public static string AsString(this TimeSpan value)
        {
            var components = new List<string>();

            if (value.Days != 0)
                components.Add(string.Format("{0} day{1}", value.Days, value.Days == 1 ? "" : "s"));

            if (value.Hours != 0)
                components.Add(string.Format("{0} hour{1}", value.Hours, value.Hours == 1 ? "" : "s"));

            if (value.Minutes != 0)
                components.Add(string.Format("{0} minute{1}", value.Minutes, value.Minutes == 1 ? "" : "s"));

            if (value.Seconds != 0)
                components.Add(string.Format("{0} second{1}", value.Seconds, value.Seconds == 1 ? "" : "s"));

            if (value.Milliseconds != 0)
                components.Add(string.Format("{0} millisecond{1}", value.Milliseconds, value.Milliseconds == 1 ? "" : "s"));

            return string.Join(" ", components);
        }

        public static string AsString(this BlobSubType value)
        {
            switch (value)
            {
                case BlobSubType.Bitmap:
                    return "Bitmap";
                case BlobSubType.Memo:
                    return "Memo";
                case BlobSubType.UserDefined:
                    return "User-Defined";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this SqlDataType value)
        {
            if (!Enum.IsDefined(value.GetType(), value))
                throw new ArgumentOutOfRangeException("value");

            return value.ToString();
        }

        public static string AsString(this XmlPortEncoding value)
        {
            switch (value)
            {
                case XmlPortEncoding.Utf8:
                    return "UTF-8";
                case XmlPortEncoding.Utf16:
                    return "UTF-16";
                case XmlPortEncoding.Iso8859Dash2:
                    return "ISO8859-2";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this XmlVersionNo value)
        {
            switch (value)
            {
                case XmlVersionNo.Version10:
                    return "1.0";
                case XmlVersionNo.Version11:
                    return "1.1";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this FormatEvaluate value)
        {
            switch (value)
            {
                case FormatEvaluate.CSideFormatEvaluate:
                    return "C/SIDE Format/Evaluate";
                case FormatEvaluate.XmlFormatEvaluate:
                    return "XML Format/Evaluate";
                default:
                    throw new ArgumentOutOfRangeException("formatEvaluate");
            }
        }

        public static string AsString(this XmlPortFormat value)
        {
            switch (value)
            {
                case XmlPortFormat.Xml:
                    return "Xml";
                case XmlPortFormat.FixedText:
                    return "Fixed Text";
                case XmlPortFormat.VariableText:
                    return "Variable Text";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this TableFieldType value)
        {
            switch (value)
            {
                case TableFieldType.Guid:
                    return "GUID";
                default:
                    return value.ToString();
            }
        }

        public static string AsString(this DataItemLinkType value)
        {
            switch (value)
            {
                case DataItemLinkType.ExcludeRowIfNoMatch:
                    return "Exclude Row If No Match";
                case DataItemLinkType.SqlAdvancedOptions:
                    return "SQL Advanced Options";
                case DataItemLinkType.UseDefaultValuesIfNoMatch:
                    return "Use Default Values if No Match";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this SqlJoinType value)
        {
            switch (value)
            {
                case SqlJoinType.CrossJoin:
                    return "Cross Join";
                case SqlJoinType.FullOuterJoin:
                    return "Full Outer Join";
                case SqlJoinType.InnerJoin:
                    return "Inner Join";
                case SqlJoinType.LeftOuterJoin:
                    return "Left Outer Join";
                case SqlJoinType.RightOuterJoin:
                    return "Right Outer Join";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this MenuItemDepartmentCategory value)
        {
            switch (value)
            {
                case MenuItemDepartmentCategory.Administration:
                case MenuItemDepartmentCategory.Documents:
                case MenuItemDepartmentCategory.History:
                case MenuItemDepartmentCategory.Lists:
                case MenuItemDepartmentCategory.Tasks:
                    return value.ToString();
                case MenuItemDepartmentCategory.ReportsAndAnalysis:
                    return "Reports and Analysis";
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }

        public static string AsString(this int? value)
        {
            if (value.HasValue)
                return value.Value.ToString();

            return string.Empty;
        }
    }
}
