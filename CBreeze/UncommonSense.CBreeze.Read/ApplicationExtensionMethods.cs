using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Parse;

namespace UncommonSense.CBreeze.Read
{
    internal static class ApplicationExtensionMethods
    {
        internal static void SetObjectReferenceProperty(this RunObjectProperty property, string propertyValue)
        {
            if (string.IsNullOrWhiteSpace(propertyValue))
                return;

            var match = Regex.Match(propertyValue, @"(\S+)\s(\d+)");

            if (!match.Success)
                throw new ArgumentOutOfRangeException(string.Format("Invalid object reference: {0}.", propertyValue));

            property.Value.Type = match.Groups[1].Value.ToNullableEnum<RunObjectType>();
            property.Value.ID = match.Groups[2].Value.ToInteger();
        }

        internal static void SetDecimalPlacesProperty(this DecimalPlacesProperty property, string propertyValue)
        {
            int? atLeast = null;
            int? atMost = null;
            var match = Patterns.DecimalPlaces.Match(propertyValue);

            if (match.Success)
            {
                atLeast = match.Groups[1].Value.ToNullableInteger();
                atMost = match.Groups[2].Value.ToNullableInteger();
            }

            property.Value.AtLeast = atLeast;
            property.Value.AtMost = atMost;
        }

#if NAV2015
        internal static void SetAccessByPermission(this AccessByPermissionProperty property, string propertyValue)
        {
            var match = Patterns.AccessByPermission.Match(propertyValue);

            property.Value.ObjectType = null;
            property.Value.ObjectID = null;
            property.Value.Read = false;
            property.Value.Insert = false;
            property.Value.Modify = false;
            property.Value.Delete = false;
            property.Value.Execute = false;

            if (match.Success)
            {
                property.Value.ObjectType = match.Groups[1].Value.ToEnum<AccessByPermissionObjectType>();
                property.Value.ObjectID = match.Groups[2].Value.ToInteger();
                property.Value.Read = match.Groups[3].Value.Contains('R');
                property.Value.Insert = match.Groups[3].Value.Contains('I');
                property.Value.Modify = match.Groups[3].Value.Contains('M');
                property.Value.Delete = match.Groups[3].Value.Contains('D');
                property.Value.Execute = match.Groups[3].Value.Contains('X');
            }
        }
#endif

        internal static void SetLinkFieldsProperty(this LinkFieldsProperty property, string propertyValue)
        {
            do
            {
                var fieldNo = Parsing.MustMatch(ref propertyValue, @"^Field(\d+)=FIELD\(").Groups[1].Value.ToInteger();
                var referenceFieldNo = Parsing.MustMatch(ref propertyValue, @"^Field(\d+)\)").Groups[1].Value.ToInteger();
                property.Value.Add(new LinkField(fieldNo, referenceFieldNo));
            }
            while (Parsing.TryMatch(ref propertyValue, @"^,\s?"));
        }

        internal static void SetMultiLanguageValue(this MultiLanguageValue multiLanguageValue, string value)
        {
            value = RemoveSurroundingSquareBrackets(value);

            while (value.Length > 0)
            {
                var languageCode = Parsing.MustMatch(ref value, @"^([A-Z@]{3})=").Groups[1].Value;
                var languageValue = GetLanguageValue(ref value);
                multiLanguageValue.Set(languageCode, languageValue);

                Parsing.TryMatch(ref value, @"^;\s?");
            }
        }

#if NAV2016
        internal static void SetNamespacesValue(this XmlPortNamespaces namespaces, string value)
        {
            value = RemoveSurroundingSquareBrackets(value);

            while (value.Length > 0)
            {
                var match = Parsing.MustMatch(ref value, @"^([^=]*)=([^;]*);?");
                var prefix = match.Groups[1].Value;
                var @namespace = match.Groups[2].Value;
                namespaces.Set(prefix, @namespace);
            }
        }
#endif

        internal static string GetLanguageValue(ref string value)
        {
            switch (value.StartsWith("\""))
            {
                case true:
                    Parsing.MustMatch(ref value, "^\"");
                    // Parsing.MustMatch(ref value, @"\""([^\""]+)\""").Groups[1].Value;
                    return Parsing.MatchUntilSingle(ref value, '"');
                default:
                    return Parsing.MustMatch(ref value, @"([^;]+)").Groups[1].Value;
            }
        }

        internal static void SetObjectLinkProperty(this RunObjectLinkProperty property, string propertyValue)
        {
            //			Payment Term=FIELD(Code);

            while (propertyValue.Length > 0)
            {
                var fieldName = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var type = Parsing.MustMatch(ref propertyValue, @"(CONST|FILTER|FIELD)").Groups[1].Value.ToEnum<TableFilterType>();
                Parsing.MustMatch(ref propertyValue, @"^\(");
                var value = Parsing.MatchUntilUnnested(ref propertyValue, ')', '(');

                property.Value.Add(new RunObjectLinkLine(fieldName, type, value));

                Parsing.TryMatch(ref propertyValue, @"^,\s?");
            }
        }

        internal static void SetSemiColonSeparatedStringProperty(this SemiColonSeparatedStringProperty property, string propertyValue)
        {
            property.Value = RemoveSurroundingSquareBrackets(propertyValue);
        }

        internal static void SetPermissionProperty(this PermissionsProperty property, string propertyValue)
        {
            // TableData 21=r
            while (propertyValue.Length > 0)
            {
                var match = Parsing.MustMatch(ref propertyValue, @"^TableData\s(\d+)=(r?)(i?)(m?)(d?)(,\s)?");
                property.Value.Set(match.Groups[1].Value.ToInteger(), match.Groups[2].Value == "r", match.Groups[3].Value == "i", match.Groups[4].Value == "m", match.Groups[5].Value == "d");
            }
        }

        internal static void SetQueryOrderByLinesProperty(this QueryOrderByLinesProperty property, string propertyValue)
        {
            //    OrderBy=Country_Region_Code=Ascending,
            //            VAT_Registration_No=Ascending;
            while (!string.IsNullOrEmpty(propertyValue))
            {
                var column = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var direction = Parsing.MustMatch(ref propertyValue, @"(Ascending|Descending),?\s?").Groups[1].Value.ToEnum<QueryOrderByDirection>();
                property.Value.Add(new QueryOrderByLine(column, direction));
            }
        }

        internal static void SetReportDataItemLinkProperty(this ReportDataItemLinkProperty property, string propertyValue)
        {
            do
            {
                var fieldName = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=FIELD\(").Groups[1].Value;
                var referenceFieldName = Parsing.MatchUntilUnnested(ref propertyValue, ')', '(');
                //var referenceFieldName = Parsing.MustMatch(ref propertyValue, @"^([^)]+)\)").Groups[1].Value;
                property.Value.Add(new ReportDataItemLinkLine(fieldName, referenceFieldName));
            }
            while (Parsing.TryMatch(ref propertyValue, @"^,\s?"));
        }

        internal static void SetSIFTLevelsProperty(this SIFTLevelsProperty property, string propertyValue)
        {
            propertyValue = RemoveSurroundingSquareBrackets(propertyValue);

            while (!string.IsNullOrEmpty(propertyValue))
            {
                var siftLevelLine = Parsing.MustMatch(ref propertyValue, @"^\{(.*?)\}").Groups[1].Value;
                var fields = siftLevelLine.Split(",".ToCharArray());
                var siftLevel = property.Value.Add(new SIFTLevel());

                foreach (var field in fields)
                {
                    var field2 = field;
                    var match = Parsing.MustMatch(ref field2, @"^([^:]+)(:(.*))?");
                    var fieldName = match.Groups[1].Value;
                    var aspect = match.Groups[3].Value;

                    siftLevel.Components.Add(new SIFTLevelComponent(fieldName, aspect));
                }

                Parsing.TryMatch(ref propertyValue, @"^,\s?");
            }
        }

        internal static void SetSourceFieldProperty(this SourceFieldProperty property, string propertyValue)
        {
            Match match;
            Parsing.TryMatch(ref propertyValue, @"^(.*)::(.*)$", out match);
            var tableVariableName = match.Groups[1].Value;
            var fieldName = match.Groups[2].Value;

            property.Value.TableVariableName = tableVariableName;
            property.Value.FieldName = fieldName;
        }

        internal static void SetTableRelationProperty(this TableRelationProperty property, string propertyValue)
        {
            while (propertyValue.Length > 0)
            {
                var conditions = GetTableRelationConditions(ref propertyValue);
                var tableName = GetTableRelationTableName(ref propertyValue);
                var fieldName = GetTableRelationFieldName(ref propertyValue);
                var filters = GetTableRelationFilters(ref propertyValue);

                var tableRelationLine = property.Value.Add(new TableRelationLine(tableName));
                tableRelationLine.FieldName = fieldName;

                foreach (var condition in conditions)
                {
                    tableRelationLine.Conditions.Add(new TableRelationCondition(condition.FieldName, condition.Type.ToEnum<SimpleTableFilterType>(), condition.Value));
                }

                foreach (var filter in filters)
                {
                    tableRelationLine.TableFilter.Add(new TableRelationTableFilterLine(filter.FieldName, filter.Type.ToEnum<TableFilterType>(), filter.Value));
                }

                Parsing.TryMatch(ref propertyValue, @"^\sELSE\s");
            }
        }

        internal static List<TableRelationFilterLine> GetTableRelationConditions(ref string propertyValue)
        {
            // ELSE IF (Type=CONST("Charge (Item)")) "Item Charge";

            var result = new List<TableRelationFilterLine>();

            if (!Parsing.TryMatch(ref propertyValue, @"^IF\s\("))
                return result;

            do
            {
                var fieldName = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var type = Parsing.MustMatch(ref propertyValue, @"(CONST|FILTER)").Groups[1].Value;
                Parsing.MustMatch(ref propertyValue, @"^\(");
                var value = Parsing.MatchUntil(ref propertyValue, ')', '"');

                result.Add(new TableRelationFilterLine(fieldName, type, value, false, false));
            }
            while (Parsing.TryMatch(ref propertyValue, @"^,\s?"));

            Parsing.MustMatch(ref propertyValue, @"^\)\s");

            return result;
        }

        internal static string GetTableRelationTableName(ref string propertyValue)
        {
            switch (propertyValue.StartsWith("\""))
            {
                case true:
                    return Parsing.MustMatch(ref propertyValue, @"\""([^\""]+)\""").Groups[1].Value;
                default:
                    return Parsing.MustMatch(ref propertyValue, @"([^\s\.]+)").Groups[1].Value;
            }
        }

        internal static string GetTableRelationFieldName(ref string propertyValue)
        {
            if (!Parsing.TryMatch(ref propertyValue, @"^\."))
                return null;

            switch (propertyValue.StartsWith("\""))
            {
                case true:
                    return Parsing.MustMatch(ref propertyValue, @"\""([^\""]+)\""").Groups[1].Value;
                default:
                    return Parsing.MustMatch(ref propertyValue, @"(\S+)").Groups[1].Value;
            }
        }

        internal static List<TableRelationFilterLine> GetTableRelationFilters(ref string propertyValue)
        {
            var result = new List<TableRelationFilterLine>();

            if (!Parsing.TryMatch(ref propertyValue, @"^\s?WHERE\s?\("))
                return result;

            do
            {
                var fieldName = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var type = Parsing.MustMatch(ref propertyValue, @"(CONST|FILTER|FIELD)").Groups[1].Value;
                Parsing.MustMatch(ref propertyValue, @"^\(");
                var value = Parsing.MatchUntilUnnested(ref propertyValue, ')', '(');
                // var value = Parsing.MustMatch(ref propertyValue, @"\(([^\)]*)\)").Groups[1].Value;
                result.Add(new TableRelationFilterLine(fieldName, type, value, false, false));
            }
            while (Parsing.TryMatch(ref propertyValue, @"^,\s?"));

            Parsing.MustMatch(ref propertyValue, @"^\)");

            return result;
        }

        internal static void SetCalcFormulaProperty(this CalcFormulaProperty property, string propertyValue)
        {
            // CalcFormula=-Sum("Detailed Vendor Ledg. Entry".Amount WHERE (Vendor No.=FIELD(Vendor Filter), Initial Entry Global Dim. 1=FIELD(Global Dimension 1 Filter), Initial Entry Global Dim. 2=FIELD(Global Dimension 2 Filter), Initial Entry Due Date=FIELD(Date Filter), Posting Date=FIELD(UPPERLIMIT(Date Filter)), Currency Code=FIELD(Code)));

            var reverseSign = GetCalcFormulaReverseSign(ref propertyValue);
            var method = GetCalcFormulaMethodText(ref  propertyValue).ToEnum<CalcFormulaMethod>();
            var tableName = GetCalcFormulaTableName(ref propertyValue);
            var fieldName = GetCalcFormulaFieldName(ref propertyValue);
            var filters = GetCalcFormulaFilters(ref propertyValue);

            property.Value.ReverseSign = reverseSign;
            property.Value.Method = method;
            property.Value.TableName = tableName;
            property.Value.FieldName = fieldName;

            foreach (var filter in filters)
            {
                var calcFormulaTableFilterLine = property.Value.TableFilter.Add(new CalcFormulaTableFilterLine(filter.FieldName, filter.Type.ToEnum<TableFilterType>(), filter.Value));
                calcFormulaTableFilterLine.ValueIsFilter = filter.ValueIsFilter;
                calcFormulaTableFilterLine.OnlyMaxLimit = filter.OnlyMaxLimit;
            }
        }

        internal static void SetColumnFilterProperty(this ColumnFilterProperty property, string propertyValue)
        {
            // ColumnFilter=Lot_No=FILTER(<>'');

            while (!string.IsNullOrEmpty(propertyValue))
            {
                var column = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var type = Parsing.MustMatch(ref propertyValue, @"^(CONST|FILTER)").Groups[1].Value.ToEnum<SimpleTableFilterType>();
                var value = Parsing.MustMatch(ref propertyValue, @"^\(([^\)]*)\)").Groups[1].Value;

                property.Value.Add(new ColumnFilterLine(column, type, value));
            }
        }

        internal static void SetDataItemLinkProperty(this QueryDataItemLinkProperty property, string propertyValue)
        {
            //Dimension Set ID=ValueEntry."Dimension Set ID",
            // Dimension Code=ItemAnalysisView."Dimension 1 Code" }

            while (!string.IsNullOrEmpty(propertyValue))
            {
                var field = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var referenceTable = Parsing.MustMatch(ref propertyValue, @"^([^\.]+).").Groups[1].Value;
                var referenceField = Parsing.MustMatch(ref propertyValue, @"^([^,]+),?\s?").Groups[1].Value;

                property.Value.Add(new QueryDataItemLinkLine(field, referenceTable, referenceField));
            }
        }

        internal static void SetDataItemQueryElementTableFilter(this DataItemQueryElementTableFilterProperty property, string propertyValue)
        {
            // DataItemTableFilter=Type=CONST(Sale)

            do
            {
                var fieldName = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var type = Parsing.MustMatch(ref propertyValue, @"^(CONST|FILTER)").Groups[1].Value.ToEnum<SimpleTableFilterType>();
                var value = GetCalcFormulaFilterValue(ref propertyValue);
                property.Value.Add(new DataItemQueryElementTableFilterLine(fieldName, type, value));
            }
            while (Parsing.TryMatch(ref propertyValue, @"^,\s?"));
        }

        internal static bool GetCalcFormulaReverseSign(ref string propertyValue)
        {
            return Parsing.TryMatch(ref propertyValue, @"^-");
        }

        internal static string GetCalcFormulaMethodText(ref string propertyValue)
        {
            return Parsing.MustMatch(ref propertyValue, @"^([^\(]+)\(").Groups[1].Value;
        }

        internal static string GetCalcFormulaTableName(ref string propertyValue)
        {
            switch (propertyValue.StartsWith("\""))
            {
                case true:
                    return Parsing.MustMatch(ref propertyValue, @"\""([^\""]+)\""").Groups[1].Value;
                default:
                    return Parsing.MustMatch(ref propertyValue, @"([^\s\.]+)").Groups[1].Value;
            }
        }

        internal static string GetCalcFormulaFieldName(ref string propertyValue)
        {
            if (!Parsing.TryMatch(ref propertyValue, @"^\."))
                return null;

            switch (propertyValue.StartsWith("\""))
            {
                case true:
                    return Parsing.MustMatch(ref propertyValue, @"\""([^\""]+)\""").Groups[1].Value;
                default:
                    return Parsing.MustMatch(ref propertyValue, @"(\S+)").Groups[1].Value;
            }
        }

        internal static List<TableRelationFilterLine> GetCalcFormulaFilters(ref string propertyValue)
        {
            var result = new List<TableRelationFilterLine>();

            if (!Parsing.TryMatch(ref propertyValue, @"^ WHERE\s\("))
                return result;

            do
            {
                var fieldName = Parsing.MustMatch(ref propertyValue, @"^([^=]+)=").Groups[1].Value;
                var type = Parsing.MustMatch(ref propertyValue, @"^(CONST|FILTER|FIELD)").Groups[1].Value;
                var valueIsFilter = GetCalcFormulaFilterValueIsFilter(ref propertyValue);
                var onlyMaxLimit = GetCalcFormulaFilterOnlyMaxLimit(ref propertyValue);
                var value = GetCalcFormulaFilterValue(ref propertyValue);
                if (onlyMaxLimit)
                    Parsing.MustMatch(ref propertyValue, @"^\)");
                if (valueIsFilter)
                    Parsing.MustMatch(ref propertyValue, @"^\)");
                result.Add(new TableRelationFilterLine(fieldName, type, value, valueIsFilter, onlyMaxLimit));
            }
            while (Parsing.TryMatch(ref propertyValue, @"^,\s?"));

            Parsing.MustMatch(ref propertyValue, @"^\)");

            return result;
        }

        internal static string GetCalcFormulaFilterValue(ref string value)
        {
            Parsing.MustMatch(ref value, @"^\(");
            return Parsing.MatchUntilUnnested(ref value, ')', '(');

            // return Parsing.MatchUntil(ref value, ')', '\'');
        }

        internal static bool GetCalcFormulaFilterValueIsFilter(ref string value)
        {
            return Parsing.TryMatch(ref value, @"^\(FILTER");
        }

        internal static bool GetCalcFormulaFilterOnlyMaxLimit(ref string value)
        {
            return Parsing.TryMatch(ref value, @"^\(UPPERLIMIT");
        }

        internal static void SetTableViewProperty(this TableViewProperty property, string propertyValue)
        {
            //			SourceTableView=SORTING(Search Description)
            //				ORDER(Ascending)
            //				WHERE(No. 2=CONST(FOO),
            //					Description=FILTER(<>''));

            property.Value.Key = GetTableViewSorting(ref propertyValue);
            property.Value.Order = GetTableViewOrder(ref propertyValue);
            property.Value.TableFilter.SetFromPropertyValue(ref propertyValue);
        }

        internal static string GetTableViewSorting(ref string propertyValue)
        {
            if (Parsing.TryMatch(ref propertyValue, @"^SORTING\("))
                return Parsing.MatchUntilUnnested(ref propertyValue, ')', '(');

            return null;
        }

        internal static Order? GetTableViewOrder(ref string propertyValue)
        {
            Match match;
            return Parsing.TryMatch(ref propertyValue, @"^\s?ORDER\((Ascending|Descending)?\)", out match) ? match.Groups[1].Value.ToNullableEnum<Order>() : null;
        }

        internal static void SetFromPropertyValue(this TableFilter tableFilter, ref string propertyValue)
        {
            if (string.IsNullOrEmpty(propertyValue))
                return;

            ///propertyValue = string.Format(" {0}", propertyValue);

            foreach (var tableRelationFilterLine in GetTableRelationFilters(ref propertyValue))
            {
                tableFilter.Add(new TableFilterLine(tableRelationFilterLine.FieldName, tableRelationFilterLine.Type.ToEnum<SimpleTableFilterType>(), tableRelationFilterLine.Value));
            }
        }

        internal static string RemoveSurroundingSquareBrackets(string value)
        {
            Match match;

            if (Parsing.TryMatch(ref value, @"^\[(.*)\]$", out match))
                return match.Groups[1].Value;

            return value;
        }
    }
}
