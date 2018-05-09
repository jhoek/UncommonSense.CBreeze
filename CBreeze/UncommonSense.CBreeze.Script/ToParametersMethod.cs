using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToParametersMethod
    {
        public static IEnumerable<ParameterBase> ToParameters(this DataItemReportElement dataItemReportElement)
        {
            yield return new SimpleParameter("ID", dataItemReportElement.ID);

            if (!string.IsNullOrEmpty(dataItemReportElement.Name))
                yield return new SimpleParameter("Name", dataItemReportElement.Name);

            yield return new ScriptBlockParameter(
                "SubObjects",
                dataItemReportElement.Properties.DataItemTableView.TableFilter.ToInvocations()
                    .Concat(dataItemReportElement.Properties.DataItemLink.Select(l => l.ToInvocation()))
                    .Concat(dataItemReportElement.Children.Select(e => e.ToInvocation()))
                    );

            foreach (var parameter in dataItemReportElement.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this ColumnReportElement columnReportElement)
        {
            yield return new SimpleParameter("ID", columnReportElement.ID);
            yield return new SimpleParameter("Name", columnReportElement.Name);

            foreach (var parameter in columnReportElement.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this ReportLabel reportLabel)
        {
            yield return new SimpleParameter("ID", reportLabel.ID);
            yield return new SimpleParameter("Name", reportLabel.Name);

            foreach (var parameter in reportLabel.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this RunObjectLinkLine runObjectLinkLine)
        {
            yield return new SimpleParameter("FieldName", runObjectLinkLine.FieldName);
            yield return new SimpleParameter("Type", runObjectLinkLine.Type);
            yield return new SimpleParameter("Value", runObjectLinkLine.Value);

            yield return new SwitchParameter("ValueIsFilter", runObjectLinkLine.ValueIsFilter);
            yield return new SwitchParameter("OnlyMaxLimit", runObjectLinkLine.OnlyMaxLimit);
        }

        public static IEnumerable<ParameterBase> ToParameters(this TableFilterLine tableFilterLine)
        {
            yield return new SimpleParameter("FieldName", tableFilterLine.FieldName);
            yield return new SimpleParameter("Type", tableFilterLine.Type);
            yield return new SimpleParameter("Value", tableFilterLine.Value);
        }

        public static IEnumerable<ParameterBase> ToParameters(this QueryOrderByLine queryOrderByLine)
        {
            yield return new SimpleParameter("Column", queryOrderByLine.Column);
            yield return new SimpleParameter("Direction", queryOrderByLine.Direction);
        }

        public static IEnumerable<ParameterBase> ToParameters(this QueryElement queryElement)
        {
            switch (queryElement)
            {
                case DataItemQueryElement d:
                    return d.ToParameters();
                case ColumnQueryElement c:
                    return c.ToParameters();
                case FilterQueryElement f:
                    return f.ToParameters();
                default:
                    return Enumerable.Empty<ParameterBase>();
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this DataItemQueryElement dataitemQueryElement)
        {
            yield return new SimpleParameter("ID", dataitemQueryElement.ID);
            yield return new SimpleParameter("Name", dataitemQueryElement.Name);

            foreach (var parameter in dataitemQueryElement.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter(
                "SubObjects",
                dataitemQueryElement.Children.Select(c => c.ToInvocation())
                .Concat(dataitemQueryElement.Properties.DataItemTableFilter.Select(f => f.ToInvocation()))
                .Concat(dataitemQueryElement.Properties.DataItemLink.Select(l => l.ToInvocation()))
            );
        }

        public static IEnumerable<ParameterBase> ToParameters(this QueryDataItemLinkLine queryDataItemLinkLine)
        {
            yield return new SimpleParameter("Field", queryDataItemLinkLine.Field);
            yield return new SimpleParameter("ReferenceTable", queryDataItemLinkLine.ReferenceTable);
            yield return new SimpleParameter("ReferenceField", queryDataItemLinkLine.ReferenceField);
        }

        public static IEnumerable<ParameterBase> ToParameters(this ReportDataItemLinkLine reportDataItemLinkLine)
        {
            yield return new SimpleParameter("Field", reportDataItemLinkLine.FieldName);
            yield return new SimpleParameter("ReferenceField", reportDataItemLinkLine.ReferenceFieldName);
        }

        public static IEnumerable<ParameterBase> ToParameters(this ColumnQueryElement columnQueryElement)
        {
            yield return new SimpleParameter("ID", columnQueryElement.ID);
            yield return new SimpleParameter("Name", columnQueryElement.Name);

            foreach (var parameter in columnQueryElement.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter(
                "SubObjects",
                columnQueryElement.Properties.ColumnFilter.Select(f => f.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this FilterQueryElement filterQueryElement)
        {
            yield return new SimpleParameter("ID", filterQueryElement.ID);
            yield return new SimpleParameter("Name", filterQueryElement.Name);

            foreach (var parameter in filterQueryElement.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this TableField field)
        {
            yield return new SimpleParameter("ID", field.ID);
            yield return new SimpleParameter("Name", field.Name);

            switch (field)
            {
                case CodeTableField c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    break;

                case TextTableField t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    break;
            }

            foreach (var parameter in field.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this Variable variable)
        {
            yield return new SimpleParameter("ID", variable.ID);
            yield return new SimpleParameter("Name", variable.Name);

            switch (variable)
            {
                case IHasDimensions d:
                    yield return new SimpleParameter("Dimensions", d.Dimensions);
                    break;
            }

            switch (variable)
            {
                case AutomationVariable a:
                    yield return new SimpleParameter("SubType", a.SubType);
                    yield return new SwitchParameter("WithEvents", a.WithEvents);
                    break;

                case BinaryVariable b:
                    yield return new SimpleParameter("DataLength", b.DataLength);
                    break;

                case BooleanVariable b:
                    yield return new SwitchParameter("IncludeInDataset", b.IncludeInDataset);
                    break;

                case CodeVariable c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    yield return new SwitchParameter("IncludeInDataset", c.IncludeInDataset);
                    break;

                case CodeunitVariable c:
                    yield return new SimpleParameter("SubType", c.SubType);
                    break;

                case DotNetVariable d:
                    yield return new SwitchParameter("RunOnClient", d.RunOnClient);
                    yield return new SimpleParameter("SubType", d.SubType);
                    yield return new SwitchParameter("WithEvents", d.WithEvents);
                    break;

                case IntegerVariable i:
                    yield return new SwitchParameter("IncludeInDataset", i.IncludeInDataset);
                    break;

                case OcxVariable o:
                    yield return new SimpleParameter("SubType", o.SubType);
                    break;

                case OptionVariable o:
                    yield return new SimpleParameter("OptionString", o.OptionString);
                    break;

                case PageVariable p:
                    yield return new SimpleParameter("SubType", p.SubType);
                    break;

                case QueryVariable q:
                    yield return new SimpleParameter("SecurityFiltering", q.SecurityFiltering);
                    yield return new SimpleParameter("SubType", q.SubType);
                    break;

                case RecordVariable r:
                    yield return new SimpleParameter("SubType", r.SubType);
                    yield return new SwitchParameter("Temporary", r.Temporary);
                    yield return new SimpleParameter("SecurityFiltering", r.SecurityFiltering);
                    break;

                case RecordRefVariable r:
                    yield return new SimpleParameter("SecurityFiltering", r.SecurityFiltering);
                    break;

                case ReportVariable r:
                    yield return new SimpleParameter("SubType", r.SubType);
                    break;

                case TestPageVariable t:
                    yield return new SimpleParameter("SubType", t.SubType);
                    break;

                case TextConstant t:
                    yield return new SimpleParameter("Values", t.Values);
                    break;

                case TextVariable t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    yield return new SwitchParameter("IncludeInDataset", t.IncludeInDataset);
                    break;

                case XmlPortVariable x:
                    yield return new SimpleParameter("SubType", x.SubType);
                    break;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this TableFieldGroup fieldGroup)
        {
            yield return new SimpleParameter("ID", fieldGroup.ID);
            yield return new SimpleParameter("Name", fieldGroup.Name);
            yield return new SimpleParameter("FieldNames", fieldGroup.Fields);

            // FIXME: Properties
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageActionContainer pageActionContainer)
        {
            yield return new SimpleParameter("ID", pageActionContainer.ID);

            foreach (var parameter in pageActionContainer.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("ChildActions", pageActionContainer.Children.Select(a => a.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageActionGroup pageActionGroup)
        {
            yield return new SimpleParameter("ID", pageActionGroup.ID);

            foreach (var parameter in pageActionGroup.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("ChildActions", pageActionGroup.Children.Select(a => a.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageAction pageAction)
        {
            yield return new SimpleParameter("ID", pageAction.ID);

            yield return new ScriptBlockParameter(
                "SubObjects",
                pageAction.Properties.RunPageLink.ToInvocations().Concat(
                    pageAction.Properties.RunPageView.TableFilter.ToInvocations()));

            foreach (var parameter in pageAction.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageActionSeparator pageActionSeparator)
        {
            yield return new SimpleParameter("ID", pageActionSeparator.ID);

            foreach (var parameter in pageActionSeparator.Properties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageControlContainer pageControlContainer)
        {
            yield return new SimpleParameter("ID", pageControlContainer.ID);

            foreach (var parameter in pageControlContainer.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("SubObjects", pageControlContainer.Children.Select(c => c.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageControlGroup pageControlGroup)
        {
            yield return new SimpleParameter("ID", pageControlGroup.ID);

            foreach (var parameter in pageControlGroup.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("SubObjects", pageControlGroup.Children.Select(c => c.ToInvocation()).Concat(pageControlGroup.Properties.ActionList.ToInvocations()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageControlPart pageControlPart)
        {
            yield return new SimpleParameter("ID", pageControlPart.ID);

            yield return new ScriptBlockParameter("SubObjects",
                pageControlPart.Properties.SubPageLink.ToInvocations()
                .Concat(pageControlPart.Properties.SubPageView.TableFilter.ToInvocations()));

            foreach (var parameter in pageControlPart.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageControlBase pageControlBase)
        {
            yield return new SimpleParameter("ID", pageControlBase.ID);

            foreach (var parameter in pageControlBase.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this Event @event)
        {
            yield return new SimpleParameter("ID", @event.ID);
            yield return new SimpleParameter("SourceID", @event.SourceID);
            yield return new SimpleParameter("Name", @event.Name);
            yield return new SimpleParameter("SourceName", @event.SourceName);
            yield return new ScriptBlockParameter("SubObjects",
                @event.Parameters.ToInvocations().Cast<Statement>()
                .Concat(@event.Variables.ToInvocations())
                .Concat(@event.CodeLines.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this Function function)
        {
            yield return new SimpleParameter("ID", function.ID);
            yield return new SimpleParameter("Name", function.Name);
            yield return new SwitchParameter("Local", function.Local);
#if NAV2016
            yield return new SwitchParameter("TryFunction", function.TryFunction);
#endif
            yield return new SimpleParameter("ReturnValueName", function.ReturnValue.Name);
            yield return new SimpleParameter("ReturnValueType", function.ReturnValue.Type);
            yield return new SimpleParameter("ReturnValueDataLength", function.ReturnValue.DataLength);
            yield return new SimpleParameter("ReturnValueDimensions", function.ReturnValue.Dimensions);
#if NAV2016
            //yield return new SimpleParameter("Event", function.Event);
            //yield return new SimpleParameter("EventType", function.EventType);
            yield return new SimpleParameter("EventPublisherObjectType", function.EventPublisherObject.Type);
            yield return new SimpleParameter("EventPublisherObjectID", function.EventPublisherObject.ID);
            yield return new SimpleParameter("EventPublisherElement", function.EventPublisherElement);
            yield return new SimpleParameter("EventFunction", function.EventFunction);
            yield return new SimpleParameter("OnMissingLicense", function.OnMissingLicense);
            yield return new SimpleParameter("OnMissingPermission", function.OnMissingPermission);
            yield return new SwitchParameter("IncludeSender", function.IncludeSender);
            yield return new SwitchParameter("GlobalVarAccess", function.GlobalVarAccess);
#endif
            yield return new SimpleParameter("TransactionModel", function.TransactionModel);
            yield return new SimpleParameter("TestFunctionType", function.TestFunctionType);
            yield return new SimpleParameter("HandlerFunctions", function.HandlerFunctions);
#if NAV2015
            yield return new SimpleParameter("UpgradeFunctionType", function.UpgradeFunctionType);
#endif
#if NAV2017
            yield return new SimpleParameter("TestPermissions", function.TestPermissions);
#endif
            yield return new ScriptBlockParameter("SubObjects",
                function.Parameters.ToInvocations().Cast<Statement>()
                        .Concat(function.CodeLines.ToInvocation()) // Select(l => new Invocation($"'{l.Replace("'", "''")}'")))
                        .Concat(function.Variables.ToInvocations()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this Parameter parameter)
        {
            yield return new SimpleParameter("ID", parameter.ID);
            yield return new SimpleParameter("Name", parameter.Name);
            yield return new SimpleParameter("Dimensions", parameter.Dimensions);
            yield return new SwitchParameter("Var", parameter.Var);

            switch (parameter)
            {
                case AutomationParameter a:
                    yield return new SimpleParameter("SubType", a.SubType);
                    break;

                case BinaryParameter b:
                    yield return new SimpleParameter("DataLength", b.DataLength);
                    break;

                case CodeParameter c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    break;

                case CodeunitParameter c:
                    yield return new SimpleParameter("SubType", c.SubType);
                    break;

                case DotNetParameter d:
                    yield return new SwitchParameter("RunOnClient", d.RunOnClient);
                    yield return new SimpleParameter("SubType", d.SubType);
                    yield return new SwitchParameter("SuppressDispose", d.SuppressDispose);
                    break;

                case OcxParameter o:
                    yield return new SimpleParameter("SubType", o.SubType);
                    break;

                case OptionParameter o:
                    yield return new SimpleParameter("OptionString", o.OptionString);
                    break;

                case PageParameter p:
                    yield return new SimpleParameter("SubType", p.SubType);
                    break;

                case QueryParameter q:
                    yield return new SimpleParameter("SecurityFiltering", q.SecurityFiltering);
                    yield return new SimpleParameter("SubType", q.SubType);
                    break;

                case RecordParameter r:
                    yield return new SimpleParameter("SubType", r.SubType);
                    yield return new SwitchParameter("Temporary", r.Temporary.GetValueOrDefault(false));
                    yield return new SimpleParameter("SecurityFiltering", r.SecurityFiltering);
                    break;

                case ReportParameter r:
                    yield return new SimpleParameter("SubType", r.SubType);
                    break;

                case TestPageParameter t:
                    yield return new SimpleParameter("SubType", t.SubType);
                    break;

                case TestRequestPageParameter t:
                    yield return new SimpleParameter("SubType", t.SubType);
                    break;

                case TextParameter t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    break;

                case XmlPortParameter x:
                    yield return new SimpleParameter("SubType", x.SubType);
                    break;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this TableRelationLine tableRelationLine)
        {
            yield return new SimpleParameter("TableName", tableRelationLine.TableName);
            yield return new SimpleParameter("FieldName", tableRelationLine.FieldName);

            yield return new ScriptBlockParameter(
               "SubObjects",
                tableRelationLine.Conditions.ToInvocations()
                .Concat(tableRelationLine.TableFilter.ToInvocations()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this CalcFormulaTableFilterLine calcFormulaTableFilterLine)
        {
            yield return new SimpleParameter("FieldName", calcFormulaTableFilterLine.FieldName);
            yield return new SimpleParameter("Type", calcFormulaTableFilterLine.Type);
            yield return new SimpleParameter("Value", calcFormulaTableFilterLine.Value);
            yield return new SwitchParameter("OnlyMaxLimit", calcFormulaTableFilterLine.OnlyMaxLimit);
            yield return new SwitchParameter("ValueIsFilter", calcFormulaTableFilterLine.ValueIsFilter);
        }

        public static IEnumerable<ParameterBase> ToParameters(this TableRelationCondition condition)
        {
            yield return new SimpleParameter("FieldName", condition.FieldName);
            yield return new SimpleParameter("Type", condition.Type);
            yield return new SimpleParameter("Value", condition.Value);
        }

        public static IEnumerable<ParameterBase> ToParameters(this TableRelationTableFilterLine tableRelationTableFilterLine)
        {
            yield return new SimpleParameter("FieldName", tableRelationTableFilterLine.FieldName);
            yield return new SimpleParameter("Type", tableRelationTableFilterLine.Type);
            yield return new SimpleParameter("Value", tableRelationTableFilterLine.Value);
        }

        public static IEnumerable<ParameterBase> ToParameters(this XmlPortNamespace xmlPortNamespace)
        {
            yield return new SimpleParameter("Prefix", xmlPortNamespace.Prefix);
            yield return new SimpleParameter("Namespace", xmlPortNamespace.Namespace);
        }

        public static IEnumerable<ParameterBase> ToParameters(this XmlPortNode xmlPortNode)
        {
            yield return new SimpleParameter("ID", xmlPortNode.ID);
            yield return new SimpleParameter("Name", xmlPortNode.NodeName);

            foreach (var parameter in xmlPortNode.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter(
                "ChildNodes",
                xmlPortNode.Children.Select(n=>n.ToInvocation()).Cast<Statement>()
                    .Concat(SourceTableViewFilter(xmlPortNode).Select(f=>f.ToInvocation()).Cast<Statement>())
                    .Concat(LinkFields(xmlPortNode).Select(l=> l.ToInvocation()).Cast<Statement>())
            );
        }

        private static IEnumerable<TableFilterLine> SourceTableViewFilter(XmlPortNode xmlPortNode)
        {
            switch (xmlPortNode)
            {
                case XmlPortTableElement e:
                    return e.Properties.SourceTableView.TableFilter;
                case XmlPortTableAttribute a:
                    return a.Properties.SourceTableView.TableFilter;
                default:
                    return Enumerable.Empty<TableFilterLine>();
            }
        }

        private static IEnumerable<LinkField> LinkFields(XmlPortNode xmlPortNode)
        {
            switch (xmlPortNode)
            {
                case XmlPortTableElement e:
                    return e.Properties.LinkFields;
                case XmlPortTableAttribute a:
                    return a.Properties.LinkFields;
                default:
                    return Enumerable.Empty<LinkField>();
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this LinkField linkField)
        {
            yield return new SimpleParameter("Field", linkField.Field);
            yield return new SimpleParameter("ReferenceField", linkField.ReferenceField);
        }

        public static IEnumerable<ParameterBase> ToParameters(this Property property, string prefix = null)
        {
            // Note: SubObject parameters should not be rendered here, since they may contain
            // values from more than one property. 

            switch (property)
            {
                // Yielded as part of SubObjects
                case ActionListProperty a:
                case ColumnFilterProperty c:
                case DataItemQueryElementTableFilterProperty f:
                case LinkFieldsProperty lf:
                case MethodTypeProperty m:
                case QueryDataItemLinkProperty l:
                case ReportDataItemLinkProperty r:
                    yield break;

                case BooleanProperty b:
                    yield return new SwitchParameter(b.Name, b.Value);
                    break;

                case TotalsMethodProperty p:
                    yield return new SimpleParameter("Method", p.Value);
                    break;

                case DateMethodProperty p:
                    yield return new SimpleParameter("Method", p.Value);
                    break;

                case TriggerProperty t:
                    yield return new ScriptBlockParameter(
                        $"{prefix}{t.Name}",
                        t.Value.Variables.ToInvocations().Concat(
                            t.Value.CodeLines.Select(c => new Invocation($"'{c.Replace("'", "''")}'"))));
                    break;

                case TableRelationProperty t:
                    yield return new ScriptBlockParameter("SubObjects", t.Value.ToInvocations());
                    break;

                case CalcFormulaProperty c:
                    yield return new SimpleParameter(c.Name, c.Value.ToInvocation());
                    break;


                case PermissionsProperty p:
                    yield return new ArrayParameter($"{prefix}{p.Name}", p.Value.ToInvocations());
                    break;

#if NAV2015
                case AccessByPermissionProperty a:
                    yield return new SimpleParameter(a.Name, a.Value.ToInvocation());
                    break;
#endif

                case DecimalPlacesProperty d:
                    yield return new SimpleParameter("DecimalPlacesAtLeast", d.Value.AtLeast);
                    yield return new SimpleParameter("DecimalPlacesAtMost", d.Value.AtMost);
                    break;

                case NullableBooleanProperty b:
                    yield return new SwitchParameter($"{prefix}{b.Name}", b.Value);
                    break;

                case PageActionContainerTypeProperty t:
                    yield return new SimpleParameter("ContainerType", t.Value);
                    break;

                case QueryOrderByLinesProperty q:
                    // Rendered elsewhere as part of SubObjects
                    break;

                case RunObjectProperty r:
                    yield return new SimpleParameter("RunObjectType", r.Value.Type);
                    yield return new SimpleParameter("RunObjectID", r.Value.ID);
                    break;

                case RunObjectLinkProperty r:
                    // Rendered elsewhere as part of SubObjects
                    break;

                case SourceFieldProperty s:
                    yield return new SimpleParameter("SourceFieldTableVariableName", s.Value.TableVariableName);
                    yield return new SimpleParameter("SourceFieldName", s.Value.FieldName);
                    break;

                case TableViewProperty t when t.Name == "DataItemTableView":
                    yield return new SimpleParameter("DataItemTableViewKey", t.Value.Key);
                    yield return new SimpleParameter("DataItemTableViewOrder", t.Value.Order);
                    // TableFilter rendered elsewhere as part of SubObjects
                    break;

                case TableViewProperty t when t.Name == "SourceTableView":
                    yield return new SimpleParameter($"SourceTableViewKey", t.Value.Key);
                    yield return new SimpleParameter($"SourceTableViewOrder", t.Value.Order);
                    // TableFilter rendered elsewhere as part of SubObjects
                    break;

                case TableViewProperty t when t.Name == "SubPageView":
                    yield return new SimpleParameter($"SubPageViewKey", t.Value.Key);
                    yield return new SimpleParameter($"SubPageViewOrder", t.Value.Order);
                    // TableFilter rendered elsewhere as part of SubObjects
                    break;

                case TableViewProperty t when t.Name == "RunPageView":
                    yield return new SimpleParameter($"RunPageViewKey", t.Value.Key);
                    yield return new SimpleParameter($"RunPageViewOrder", t.Value.Order);
                    // TableFilter rendered elsewhere as part of SubObjects
                    break;

                default:
                    yield return new SimpleParameter($"{prefix}{property.Name}", property.GetValue());
                    break;
            }
        }
    }
}