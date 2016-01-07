using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using System.Globalization;

namespace UncommonSense.CBreeze.Write
{
    public static class PropertyWriter
    {
        public static void Write(this Property property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            if (style == PropertiesStyle.Object)
                isLastProperty = false;

            TypeSwitch.Do(
                property,
#if NAV2015
                TypeSwitch.Case<AccessByPermissionProperty>(p => WriteSimpleProperty(p.Name, string.Format("{0} {1}={2}", p.Value.ObjectType, p.Value.ObjectID, p.Value.ToString()), isLastProperty, writer)),
                TypeSwitch.Case<PreviewModeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageActionScopeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<UpdatePropagationProperty>(p=>WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DefaultLayoutProperty>(p=> WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
#endif
#if NAV2016
                TypeSwitch.Case<TableTypeProperty>(p=>WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<EventSubscriberInstanceProperty>(p=>WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
#endif
                TypeSwitch.Case<MenuItemRunObjectTypeProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<MenuItemDepartmentCategoryProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<PaperSourceProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DataItemLinkTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<SqlJoinTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<TextEncodingProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<QueryDataItemLinkProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ReportDataItemLinkProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ColumnFilterProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ReadStateProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<MethodTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DateMethodProperty>(p => WriteSimpleProperty("Method", p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TotalsMethodProperty>(p => WriteSimpleProperty("Method", p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TableFieldTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<TextTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<TransactionTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<DirectionProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlPortEncodingProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlVersionNoProperty>(p => WriteSimpleProperty("XMLVersionNo", p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<XmlPortFormatProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<ControlListProperty>(p => WriteSimpleProperty(p.Name, string.Join(",", p.Value), isLastProperty, writer)),
                TypeSwitch.Case<RunObjectLinkProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<StyleProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PromotedCategoryProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<RunPageModeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ObjectProperty>(p => WriteSimpleProperty(p.Name, p.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ImportanceProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PermissionsProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<ActionListProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<FieldListProperty>(p => WriteSimpleProperty(p.Name, string.Join(",", p.Value), isLastProperty, writer)),
                TypeSwitch.Case<LinkFieldsProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<CalcFormulaProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TableViewProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<DecimalPlacesProperty>(p => WriteSimpleProperty(p.Name, string.Format("{0}:{1}", p.Value.AtLeast.AsString(), p.Value.AtMost.AsString()), isLastProperty, writer)),
                TypeSwitch.Case<SourceFieldProperty>(p => WriteSimpleProperty(p.Name, string.Format("{0}::{1}", p.Value.TableVariableName, p.Value.FieldName), isLastProperty, writer)),
                TypeSwitch.Case<FieldClassProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ContainerTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<GroupTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<GroupPageControlLayoutProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PartTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<PageTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<SystemPartIDProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ActionContainerTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ScopedTriggerProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TriggerProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<SemiColonSeparatedStringProperty>(p => WriteSimpleProperty(p.Name, p.Value.Contains(";") ? string.Format("[{0}]", p.Value) : p.Value, isLastProperty, writer)),
                TypeSwitch.Case<StringProperty>(p => WriteSimpleProperty(p.Name, p.Value, isLastProperty, writer)),
                TypeSwitch.Case<OptionStringProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<DurationProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<AutoFormatTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.Value.ToString("d"), isLastProperty, writer)),
                TypeSwitch.Case<CodeunitSubTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.Value.ToString(), isLastProperty, writer)),
                TypeSwitch.Case<ExtendedDataTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.Value.AsString(), isLastProperty, writer)),
                TypeSwitch.Case<SqlDataTypeProperty>(p => WriteSimpleProperty("SQL Data Type", p.Value.Value.AsString(), isLastProperty, writer)),
                TypeSwitch.Case<BlankNumbersProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<StandardDayTimeUnitProperty>(p => WriteSimpleProperty("Standard Day/Time Unit", p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<BlobSubTypeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().AsString(), isLastProperty, writer)),
                TypeSwitch.Case<FormatEvaluateProperty>(p => WriteSimpleProperty("Format/Evaluate", p.Value.Value.AsString(), isLastProperty, writer)),
                TypeSwitch.Case<MinOccursProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<MaxOccursProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<OccurrenceProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<MultiLanguageProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TableRelationProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TableReferenceProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<PageReferenceProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<RunObjectProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<QueryOrderByLinesProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<DataItemQueryElementTableFilterProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<SIFTLevelsProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<TestIsolationProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<NullableBooleanProperty>(p => p.Write(isLastProperty, style, writer)),
                TypeSwitch.Case<NullableDateTimeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString("dd-MM-yy HH:mm"), isLastProperty, writer)),
                TypeSwitch.Case<NullableDateProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString("dd-MM-yy"), isLastProperty, writer)),
                TypeSwitch.Case<NullableDecimalProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<NullableBigIntegerProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<NullableGuidProperty>(p => WriteSimpleProperty(p.Name, string.Format("[{0}]", p.Value.GetValueOrDefault().ToString("B").ToUpper()), isLastProperty, writer)),
                TypeSwitch.Case<NullableIntegerProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString(), isLastProperty, writer)),
                TypeSwitch.Case<NullableTimeProperty>(p => WriteSimpleProperty(p.Name, p.Value.GetValueOrDefault().ToString("c"), isLastProperty, writer))
            );
        }

        public static void WriteSimpleProperty(string propertyName, string propertyValue, bool isLastProperty, CSideWriter writer)
        {
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", propertyName, propertyValue);
                    break;
                case false:
                    writer.WriteLine("{0}={1};", propertyName, propertyValue);
                    break;
            }
        }

        public static void Write(this RunObjectLinkProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());

                switch (isLastProperty && isLastLine)
                {
                    case true:
                        writer.Write("{0}={1}({2}) ", line.FieldName, line.Type.GetValueOrDefault().AsString(), line.Value);
                        break;
                    case false:
                        writer.Write("{0}={1}({2})", line.FieldName, line.Type.GetValueOrDefault().AsString(), line.Value);
                        writer.WriteLineIf(isLastLine, ";");
                        writer.WriteLineIf(!isLastLine, ",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this PermissionsProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var permission in property.Value)
            {
                var isLastValue = (permission == property.Value.Last());
                var terminator = isLastValue ? ";" : ",";
                var read = permission.ReadPermission ? "r" : "";
                var insert = permission.InsertPermission ? "i" : "";
                var modify = permission.ModifyPermission ? "m" : "";
                var delete = permission.DeletePermission ? "d" : "";

                writer.WriteLine("TableData {0}={1}{2}{3}{4}{5}", permission.TableID, read, insert, modify, delete, terminator);
            }

            writer.Unindent();
        }

        public static void Write(this ActionListProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.WriteLine("{0}=ACTIONS", property.Name);
            writer.WriteLine("{");
            writer.Indent();

            foreach (var action in property.Value)
            {
                action.Write(writer);
            }

            writer.Unindent();
            writer.WriteLine("}");
        }

        public static void Write(this LinkFieldsProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var linkField in property.Value)
            {
                writer.Write("Field{0}=FIELD(Field{1})", linkField.Field, linkField.ReferenceField);

                var isLastLine = (linkField == property.Value.Last());

                if (!isLastLine)
                    writer.WriteLine(",");
                else
                    if (isLastProperty)
                        writer.Write(" ");
                    else
                        writer.WriteLine(";");
            }

            writer.Unindent();
        }

        public static void Write(this CalcFormulaProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}={1}{2}(", property.Name, property.Value.ReverseSign ? "-" : "", property.Value.Method);

            switch (property.Value.Method.Value)
            {
                case CalcFormulaMethod.Exist:
                case CalcFormulaMethod.Count:
                    writer.Write(property.Value.TableName.QuotedExcept('-', '/', '.'));
                    break;
                case CalcFormulaMethod.Lookup:
                case CalcFormulaMethod.Average:
                case CalcFormulaMethod.Max:
                case CalcFormulaMethod.Min:
                case CalcFormulaMethod.Sum:
                    writer.Write("{0}.{1}", property.Value.TableName.QuotedExcept('-', '/', '.'), property.Value.FieldName.QuotedExcept('-', '/', '.'));
                    break;
            }

            if (property.Value.TableFilter.Any())
            {
                writer.Write(" WHERE (");
                writer.Indent(writer.Column);

                foreach (var tableFilterLine in property.Value.TableFilter)
                {
                    var value = tableFilterLine.Value;
                    if (tableFilterLine.ValueIsFilter)
                        value = string.Format("FILTER({0})", value);
                    if (tableFilterLine.OnlyMaxLimit)
                        value = string.Format("UPPERLIMIT({0})", value);

                    writer.Write("{0}={1}({2})", tableFilterLine.FieldName, tableFilterLine.Type.AsString(), value);
                    if (tableFilterLine != property.Value.TableFilter.Last())
                        writer.WriteLine(",");
                }
                writer.Write(")");
                writer.Unindent();
            }

            writer.Write(")");

            if (!isLastProperty)
                writer.WriteLine(";");
        }

        public static void Write(this TableViewProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var components = new List<string>();

            if (!string.IsNullOrEmpty(property.Value.Key))
                components.Add(string.Format("SORTING({0})", property.Value.Key));

            if (property.Value.Order.HasValue)
                components.Add(string.Format("ORDER({0})", property.Value.Order));

            if (property.Value.TableFilter.Any())
                components.AddRange(property.Value.TableFilter.AsStrings());

            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var component in components)
            {
                var isLastComponent = (component == components.Last());

                switch (isLastProperty && isLastComponent)
                {
                    case true:
                        writer.Write("{0} ", component);
                        break;
                    case false:
                        writer.Write(component);
                        writer.WriteLineIf(isLastComponent, ";");
                        writer.WriteLineIf(!isLastComponent, string.Empty);
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this TriggerProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);
            property.Value.Variables.Write(writer);

            writer.WriteLine("BEGIN");
            writer.Indent();
            property.Value.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");

            writer.Unindent();

            if (!isLastProperty || style == PropertiesStyle.Object)
                writer.InnerWriter.WriteLine();
        }

        public static void Write(this ScopedTriggerProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.ScopedName());
            writer.Indent(writer.Column);
            property.Value.Variables.Write(writer);

            writer.WriteLine("BEGIN");
            writer.Indent();
            property.Value.CodeLines.Write(writer);
            writer.Unindent();
            writer.WriteLine("END;");

            writer.Unindent();

            if (!isLastProperty || style == PropertiesStyle.Object)
                writer.InnerWriter.WriteLine();
        }

        public static void Write(this OptionStringProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var value = (property.Value.Trim() != property.Value) ? string.Format("[{0}]", property.Value) : property.Value;

            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", property.Name, value);
                    break;
                case false:
                    writer.WriteLine("{0}={1};", property.Name, value);
                    break;
            }
        }

        public static void Write(this NullableBooleanProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} ", property.Name, property.Value.Value ? "Yes" : "No");
                    break;
                case false:
                    writer.WriteLine("{0}={1};", property.Name, property.Value.Value ? "Yes" : "No");
                    break;
            }
        }

        public static void Write(this MultiLanguageProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var requiresBrackets = (
                property.Value.Count() > 1 ||
                property.Value.Any(e => e.Value.Contains('{') ||
                property.Value.Any(f => f.Value.Contains(';'))));

            writer.Write("{0}=", property.Name);
            if (requiresBrackets)
                writer.Write("[");
            writer.Indent(writer.Column);

            foreach (var multiLanguageEntry in property.Value.OrderBy(e => e.LanguageID.GetLCIDFromLanguageCode()))
            {
                writer.Write("{0}={1}", multiLanguageEntry.LanguageID, multiLanguageEntry.QuotedValue);
                writer.WriteLineIf(multiLanguageEntry != property.Value.Last(), ";");
            }

            writer.Unindent();
            if (requiresBrackets)
                writer.Write("]");

            switch (style)
            {
                case PropertiesStyle.Object:
                    writer.WriteLine(";");
                    break;
                case PropertiesStyle.Field:
                    if (!isLastProperty)
                        writer.WriteLine(";");
                    else
                        writer.Write(" ");
                    break;
            }
        }

        public static void Write(this TableRelationProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            var indentations = 0;

            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);
            indentations++;

            foreach (var tableRelationLine in property.Value)
            {
                if (tableRelationLine != property.Value.First())
                    writer.Write("ELSE ");

                if (tableRelationLine.Conditions.Any())
                {
                    writer.Write("IF (");

                    // Only indent if multiple conditions exist. 
                    // Note that C/SIDE doesn't properly unindent.
                    if (tableRelationLine.Conditions.Count() > 1)
                    {
                        writer.Indent(writer.Column); // conditions
                        indentations++;
                    }

                    foreach (var condition in tableRelationLine.Conditions)
                    {
                        writer.Write("{0}={1}({2})", condition.FieldName, condition.Type.ToString().ToUpper(), condition.Value);

                        var isLastCondition = (condition == tableRelationLine.Conditions.Last());

                        switch (isLastCondition)
                        {
                            case false:
                                writer.WriteLine(",");
                                break;
                        }
                    }

                    writer.Write(") ");
                }

                writer.Write(tableRelationLine.TableName.QuotedExcept('/', '.', '-'));

                if (!string.IsNullOrEmpty(tableRelationLine.FieldName))
                {
                    writer.Write(".{0}", tableRelationLine.FieldName.QuotedExcept('/', '.', '-'));
                }

                if (tableRelationLine.TableFilter.Any())
                {
                    writer.Write(" WHERE (");

                    if (tableRelationLine.TableFilter.Count() > 1)
                    {
                        writer.Indent(writer.Column); // filters
                        indentations++;
                    }

                    foreach (var tableFilterLine in tableRelationLine.TableFilter)
                    {
                        writer.Write("{0}={1}({2})", tableFilterLine.FieldName, tableFilterLine.Type.AsString(), tableFilterLine.Value);

                        switch (tableFilterLine == tableRelationLine.TableFilter.Last())
                        {
                            case true:
                                writer.Write(")");
                                break;
                            default:
                                writer.WriteLine(",");
                                break;
                        }
                    }
                }

                var isLastLine = (tableRelationLine == property.Value.Last());

                if (!isLastLine)
                    writer.WriteLine("");
                else
                    if (isLastProperty)
                        writer.Write(" ");
                    else
                        writer.WriteLine(";");

                //switch (tableRelationLine == property.Value.Last() && !isLastProperty)
                //{
                //    case true:
                //        writer.WriteLine(";");
                //        break;
                //    default:
                //        writer.Write(" ");
                //        break;
                //}
            }

            for (var i = 0; i < indentations; i++)
                writer.Unindent();
        }

        public static void Write(this TableReferenceProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}=Table{1} ", property.Name, property.Value.Value);
                    break;
                case false:
                    writer.WriteLine("{0}=Table{1};", property.Name, property.Value.Value);
                    break;
            }
        }

        public static void Write(this PageReferenceProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}=Page{1} ", property.Name, property.Value.Value);
                    break;
                case false:
                    writer.WriteLine("{0}=Page{1};", property.Name, property.Value.Value);
                    break;
            }
        }

        public static void Write(this RunObjectProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            switch (isLastProperty)
            {
                case true:
                    writer.Write("{0}={1} {2} ", property.Name, FormatRunObjectType(property.Value.Type.Value), property.Value.ID);
                    break;
                case false:
                    writer.WriteLine("{0}={1} {2};", property.Name, FormatRunObjectType(property.Value.Type.Value), property.Value.ID);
                    break;
            }
        }

        private static string FormatRunObjectType(RunObjectType value)
        {
            switch (value)
            {
                case RunObjectType.XmlPort:
                    return "XMLport";
                default:
                    return value.ToString();
            }
        }

        public static void Write(this MenuItemRunObjectTypeProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}={1}", property.Name, FormatMenuItemRunObjectType(property.Value.Value));
            writer.WriteIf(isLastProperty, " ");
            writer.WriteLineIf(!isLastProperty, ";");
        }

        private static string FormatMenuItemRunObjectType(MenuItemRunObjectType value)
        {
            switch (value)
            {
                case MenuItemRunObjectType.XmlPort:
                    return "XMLport";
                default:
                    return value.ToString();
            }
        }

        public static void Write(this QueryOrderByLinesProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());
                writer.WriteLine("{0}={1}{2}", line.Column, line.Direction, isLastLine ? ";" : ",");
            }

            writer.Unindent();
        }

        public static void Write(this DataItemQueryElementTableFilterProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());
                writer.Write("{0}={1}({2})", line.FieldName, line.Type.Value.AsString(), line.Value);

                switch (isLastLine)
                {
                    case true:
                        if (isLastProperty)
                        {
                            writer.Write(" ");
                        }
                        else
                        {
                            writer.WriteLine(";");
                        }

                        break;

                    case false:
                        writer.WriteLine(",");
                        break;
                }

            }

            writer.Unindent();
        }

        public static void Write(this ColumnFilterProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());
                writer.WriteLine("{0}={1}({2}){3}", line.Column, line.Type.AsString(), line.Value, isLastLine ? ";" : ",");
            }

            writer.Unindent();
        }

        public static void Write(this QueryDataItemLinkProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());

                switch (isLastProperty && isLastLine)
                {
                    case true:
                        writer.Write("{0}={1}.{2} ", line.Field, line.ReferenceTable, line.ReferenceField);
                        break;
                    case false:
                        writer.WriteLine("{0}={1}.{2}{3}", line.Field, line.ReferenceTable, line.ReferenceField, isLastLine ? ";" : ",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this ReportDataItemLinkProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            writer.Write("{0}=", property.Name);
            writer.Indent(writer.Column);

            foreach (var line in property.Value)
            {
                var isLastLine = (line == property.Value.Last());

                switch (isLastProperty && isLastLine)
                {
                    case true:
                        writer.Write("{0}=FIELD({1}) ", line.FieldName, line.ReferenceFieldName);
                        break;
                    case false:
                        writer.WriteLine("{0}=FIELD({1}){2}", line.FieldName, line.ReferenceFieldName, isLastLine ? ";" : ",");
                        break;
                }
            }

            writer.Unindent();
        }

        public static void Write(this SIFTLevelsProperty property, bool isLastProperty, PropertiesStyle style, CSideWriter writer)
        {
            //SIFTLevelsToMaintain=[{G/L Account No.,Global Dimension 1 Code},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code,Posting Date:Year},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code,Posting Date:Month},
            //          {G/L Account No.,Global Dimension 1 Code,Global Dimension 2 Code,Posting Date:Day}] }

            writer.Write("{0}=[", property.Name);
            writer.Indent(writer.Column);

            foreach (var siftLevel in property.Value)
            {
                writer.Write("{");
                writer.Write(string.Join(",", siftLevel.Components.Select(f => f.FieldName + (!string.IsNullOrEmpty(f.Aspect) ? string.Format(":{0}", f.Aspect) : string.Empty))));

                var isLastLine = (siftLevel == property.Value.Last());

                switch (isLastLine)
                {
                    case true:
                        switch (isLastProperty)
                        {
                            case true:
                                writer.Write("}] ");
                                break;
                            default:
                                writer.WriteLine("}];");
                                break;
                        }
                        break;
                    default:
                        writer.WriteLine("},");
                        break;
                }
            }

            writer.Unindent();
        }
    }
}
