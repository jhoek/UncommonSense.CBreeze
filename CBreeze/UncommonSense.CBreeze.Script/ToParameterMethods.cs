using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class ToParameterMethods
    {
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
                case BooleanVariable b:
                    yield return new SimpleParameter("Dimensions", b.Dimensions);
                    yield return new SwitchParameter("IncludeInDataset", b.IncludeInDataset);
                    break;

                case CodeVariable c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    yield return new SimpleParameter("Dimensions", c.Dimensions);
                    yield return new SwitchParameter("IncludeInDataset", c.IncludeInDataset);
                    break;

                case CodeunitVariable c:
                    yield return new SimpleParameter("Dimensions", c.Dimensions);
                    yield return new SimpleParameter("SubType", c.SubType);
                    break;

                case DateVariable d:
                    yield return new SimpleParameter("Dimensions", d.Dimensions);
                    break;

                case DecimalVariable d:
                    yield return new SimpleParameter("Dimensions", d.Dimensions);
                    break;

                case DotNetVariable d:
                    yield return new SimpleParameter("Dimensions", d.Dimensions);
                    yield return new SwitchParameter("RunOnClient", d.RunOnClient);
                    yield return new SimpleParameter("SubType", d.SubType);
                    yield return new SwitchParameter("WithEvents", d.WithEvents);
                    break;

                case FieldRefVariable f:
                    yield return new SimpleParameter("Dimensions", f.Dimensions);
                    break;

                case IntegerVariable i:
                    yield return new SimpleParameter("Dimensions", i.Dimensions);
                    yield return new SwitchParameter("IncludeInDataset", i.IncludeInDataset);
                    break;

                case OptionVariable o:
                    yield return new SimpleParameter("Dimensions", o.Dimensions);
                    yield return new SimpleParameter("OptionString", o.OptionString);
                    break;

                case PageVariable p:
                    yield return new SimpleParameter("Dimensions", p.Dimensions);
                    yield return new SimpleParameter("SubType", p.SubType);
                    break;

                case QueryVariable q:
                    yield return new SimpleParameter("Dimensions", q.Dimensions);
                    yield return new SimpleParameter("SecurityFiltering", q.SecurityFiltering);
                    yield return new SimpleParameter("SubType", q.SubType);
                    break;

                case RecordVariable r:
                    yield return new SimpleParameter("Dimensions", r.Dimensions);
                    yield return new SimpleParameter("SubType", r.SubType);
                    yield return new SwitchParameter("Temporary", r.Temporary);
                    break;

                case ReportVariable r:
                    yield return new SimpleParameter("Dimensions", r.Dimensions);
                    yield return new SimpleParameter("SubType", r.SubType);
                    break;

                case TextConstant t:
                    yield return new SimpleParameter("Values", t.Values);
                    break;

                case TextVariable t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    yield return new SimpleParameter("Dimensions", t.Dimensions);
                    yield return new SwitchParameter("IncludeInDataset", t.IncludeInDataset);
                    break;

                case XmlPortVariable x:
                    yield return new SimpleParameter("Dimensions", x.Dimensions);
                    yield return new SimpleParameter("SubType", x.SubType);
                    break;
            }

            // FIXME : Remaining types
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

            yield return new ScriptBlockParameter("ChildActions", pageActionContainer.ChildPageActions.Select(a => a.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageActionGroup pageActionGroup)
        {
            yield return new SimpleParameter("ID", pageActionGroup.ID);

            foreach (var parameter in pageActionGroup.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("ChildActions", pageActionGroup.ChildPageActions.Select(a => a.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageAction pageAction)
        {
            yield return new SimpleParameter("ID", pageAction.ID);

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

            yield return new ScriptBlockParameter("ChildControls", pageControlContainer.ChildPageControls.Select(c => c.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageControlGroup pageControlGroup)
        {
            yield return new SimpleParameter("ID", pageControlGroup.ID);

            foreach (var parameter in pageControlGroup.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("ChildControls", pageControlGroup.ChildPageControls.Select(c => c.ToInvocation()));
        }

        public static IEnumerable<ParameterBase> ToParameters(this PageControlBase pageControlBase)
        {
            yield return new SimpleParameter("ID", pageControlBase.ID);

            foreach (var parameter in pageControlBase.AllProperties.WithAValue.SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> ToParameters(this Function function)
        {
            yield return new SimpleParameter("ID", function.ID);
            yield return new SimpleParameter("Name", function.Name);
            yield return new SwitchParameter("Local", function.Local);
            yield return new SwitchParameter("TryFunction", function.TryFunction);
            yield return new SimpleParameter("ReturnValueName", function.ReturnValue.Name);
            yield return new SimpleParameter("ReturnValueType", function.ReturnValue.Type);
            yield return new SimpleParameter("ReturnValueDataLength", function.ReturnValue.DataLength);
            yield return new SimpleParameter("ReturnValueDimensions", function.ReturnValue.Dimensions);
            yield return new SwitchParameter("IncludeSender", function.IncludeSender);
            yield return new ScriptBlockParameter("SubObjects",
                function.Parameters.Select(
                    p => p.ToInvocation())
                        .Concat(function.CodeLines.Select(l => new Invocation($"'{l.Replace("'", "''")}'")))
                        .Concat(function.Variables.Select(v => v.ToInvocation()))
                    );
        }

        public static IEnumerable<ParameterBase> ToParameters(this Parameter parameter)
        {
            yield return new SimpleParameter("ID", parameter.ID);
            yield return new SimpleParameter("Name", parameter.Name);
            yield return new SimpleParameter("Dimensions", parameter.Dimensions);
            yield return new SwitchParameter("Var", parameter.Var);

            switch (parameter)
            {
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

                case OptionParameter o:
                    yield return new SimpleParameter("OptionString", o.OptionString);
                    break;

                case QueryParameter q:
                    yield return new SimpleParameter("SecurityFiltering", q.SecurityFiltering);
                    yield return new SimpleParameter("SubType", q.SubType);
                    break;

                case ReportParameter r:
                    yield return new SimpleParameter("SubType", r.SubType);
                    break;

                case TextParameter t:
                    yield return new SimpleParameter("DataLength", t.DataLength);
                    break;

                case RecordParameter r:
                    yield return new SimpleParameter("SubType", r.SubType);

                    if (r.Temporary.GetValueOrDefault(false))
                        yield return new SwitchParameter("Temporary", r.Temporary);
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

        public static IEnumerable<ParameterBase> ToParameters(this Property property)
        {
            switch (property)
            {
                case PageActionContainerTypeProperty t:
                    yield return new SimpleParameter("ContainerType", t.Value);
                    break;

                case NullableBooleanProperty b:
                    yield return new SwitchParameter(b.Name, b.Value);
                    break;

                case BooleanProperty b:
                    yield return new SwitchParameter(b.Name, b.Value);
                    break;

                case TriggerProperty t:
                    yield return new ScriptBlockParameter(
                        t.Name,
                        t.Value.Variables.ToInvocation().Concat(
                            t.Value.CodeLines.Select(c => new Invocation($"'{c.Replace("'", "''")}'"))));
                    break;

                case TableRelationProperty t:
                    yield return new ScriptBlockParameter("SubObjects", t.Value.ToInvocations());
                    break;

                case CalcFormulaProperty c:
                    yield return new SimpleParameter(c.Name, c.Value.ToInvocation());
                    break;

                case PermissionsProperty p:
                    yield return new ArrayParameter(p.Name, p.Value.ToInvocations());
                    break;

                case AccessByPermissionProperty a:
                    yield return new SimpleParameter(a.Name, a.Value.ToInvocation());
                    break;

                case DecimalPlacesProperty d:
                    yield return new SimpleParameter("DecimalPlacesAtLeast", d.Value.AtLeast);
                    yield return new SimpleParameter("DecimalPlacesAtMost", d.Value.AtMost);
                    break;

                case RunObjectProperty r:
                    yield return new SimpleParameter("RunObjectType", r.Value.Type);
                    yield return new SimpleParameter("RunObjectID", r.Value.ID);
                    break;

                case PageControlPartTypeProperty p:
                    // No parameter should be yielded for the part type
                    break;

                default:
                    yield return new SimpleParameter(property.Name, property.GetValue());
                    break;
            }
        }
    }
}