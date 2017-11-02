using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class ToInvocationMethods
    {
        private static string FunctionType(Function function)
        {
            if (function.TestFunctionType.HasValue)
                return "TestFunction";
            if (function.UpgradeFunctionType.HasValue)
                return "UpgradeFunction";
            if (!function.Event.HasValue)
                return "Function";
            if (function.Event == EventPublisherSubscriber.Subscriber)
                return "EventSubscriberFunction";
            if (function.EventType == EventType.Business)
                return "BusinessEventPublisherFunction";

            return "IntegrationEventPublisherFunction";
        }

        public static IEnumerable<Invocation> ToInvocation(this TableFields fields) => fields.Select(f => f.ToInvocation());

        public static IEnumerable<ParameterBase> Parameters(this TableField field)
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

        public static IEnumerable<ParameterBase> Parameters(this Variable variable)
        {
            yield return new SimpleParameter("ID", variable.ID);
            yield return new SimpleParameter("Name", variable.Name);

            switch (variable)
            {
                case BooleanVariable b:
                    yield return new SimpleParameter("Dimensions", b.Dimensions);
                    break;

                case CodeVariable c:
                    yield return new SimpleParameter("DataLength", c.DataLength);
                    yield return new SimpleParameter("Dimensions", c.Dimensions);
                    yield return new SimpleParameter("IncludeInDataset", c.IncludeInDataset);
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
                    yield return new SimpleParameter("RunOnClient", d.RunOnClient);
                    yield return new SimpleParameter("SubType", d.SubType);
                    yield return new SimpleParameter("WithEvents", d.WithEvents);
                    break;

                case FieldRefVariable f:
                    yield return new SimpleParameter("Dimensions", f.Dimensions);
                    break;

                case IntegerVariable i:
                    yield return new SimpleParameter("Dimensions", i.Dimensions);
                    yield return new SimpleParameter("IncludeInDataset", i.IncludeInDataset);
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
                    yield return new SimpleParameter("Temporary", r.Temporary);
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
                    yield return new SimpleParameter("IncludeInDataset", t.IncludeInDataset);
                    break;

                case XmlPortVariable x:
                    yield return new SimpleParameter("Dimensions", x.Dimensions);
                    yield return new SimpleParameter("SubType", x.SubType);
                    break;
            }

            // FIXME : Remaining types
        }

        public static IEnumerable<ParameterBase> Parameters(this TableFieldGroup fieldGroup)
        {
            yield return new SimpleParameter("ID", fieldGroup.ID);
            yield return new SimpleParameter("Name", fieldGroup.Name);
            yield return new SimpleParameter("FieldNames", fieldGroup.Fields);

            // FIXME: Properties
        }

        public static IEnumerable<ParameterBase> Parameters(this PageActionContainer pageActionContainer, IEnumerable<PageActionBase> children)
        {
            yield return new SimpleParameter("ID", pageActionContainer.ID);

            foreach (var parameter in pageActionContainer.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("ChildActions", children.ToInvocation(1));
        }

        public static IEnumerable<ParameterBase> Parameters(this PageActionGroup pageActionGroup, IEnumerable<PageActionBase> children)
        {
            yield return new SimpleParameter("ID", pageActionGroup.ID);

            foreach (var parameter in pageActionGroup.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }

            yield return new ScriptBlockParameter("ChildActions", children.ToInvocation(pageActionGroup.IndentationLevel.GetValueOrDefault(0) + 1));
        }

        public static IEnumerable<ParameterBase> Parameters(this PageAction pageAction)
        {
            yield return new SimpleParameter("ID", pageAction.ID);

            foreach (var parameter in pageAction.Properties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        public static IEnumerable<ParameterBase> Parameters(this Function function)
        {
            yield return new SimpleParameter("ID", function.ID);
            yield return new SimpleParameter("Name", function.Name);
            yield return new SimpleParameter("Local", function.Local);
            yield return new SimpleParameter("TryFunction", function.TryFunction);
            yield return new SimpleParameter("ReturnValueName", function.ReturnValue.Name);
            yield return new SimpleParameter("ReturnValueType", function.ReturnValue.Type);
            yield return new SimpleParameter("ReturnValueDataLength", function.ReturnValue.DataLength);
            yield return new SimpleParameter("ReturnValueDimensions", function.ReturnValue.Dimensions);
            yield return new SimpleParameter("IncludeSender", function.IncludeSender);
            yield return new ScriptBlockParameter("SubObjects",
                function.Parameters.Select(
                    p => p.ToInvocation())
                        .Concat(function.CodeLines.Select(l => new Invocation($"'{l.Replace("'", "''")}'")))
                        .Concat(function.Variables.Select(v => v.ToInvocation()))
                    );
        }

        public static IEnumerable<ParameterBase> Parameters(this Parameter parameter)
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
                    yield return new SimpleParameter("RunOnClient", d.RunOnClient);
                    yield return new SimpleParameter("SubType", d.SubType);
                    yield return new SimpleParameter("SuppressDispose", d.SuppressDispose);
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
                    yield return new SimpleParameter("Temporary", r.Temporary);
                    break;
            }
        }

        public static IEnumerable<ParameterBase> Parameters(this TableRelationLine tableRelationLine)
        {
            yield return new SimpleParameter("TableName", tableRelationLine.TableName);
            yield return new SimpleParameter("FieldName", tableRelationLine.FieldName);

            yield return new ScriptBlockParameter(
               "SubObjects",
                tableRelationLine.Conditions.ToInvocations()
                .Concat(tableRelationLine.TableFilter.ToInvocations()));
        }

        public static IEnumerable<ParameterBase> Parameters(this CalcFormulaTableFilterLine calcFormulaTableFilterLine)
        {
            yield return new SimpleParameter("FieldName", calcFormulaTableFilterLine.FieldName);
            yield return new SimpleParameter("Type", calcFormulaTableFilterLine.Type);
            yield return new SimpleParameter("Value", calcFormulaTableFilterLine.Value);
            yield return new SwitchParameter("OnlyMaxLimit", calcFormulaTableFilterLine.OnlyMaxLimit);
            yield return new SwitchParameter("ValueIsFilter", calcFormulaTableFilterLine.ValueIsFilter);
        }

        public static IEnumerable<ParameterBase> Parameters(this TableRelationCondition condition)
        {
            yield return new SimpleParameter("FieldName", condition.FieldName);
            yield return new SimpleParameter("Type", condition.Type);
            yield return new SimpleParameter("Value", condition.Value);
        }

        public static IEnumerable<ParameterBase> Parameters(this TableRelationTableFilterLine tableRelationTableFilterLine)
        {
            yield return new SimpleParameter("FieldName", tableRelationTableFilterLine.FieldName);
            yield return new SimpleParameter("Type", tableRelationTableFilterLine.Type);
            yield return new SimpleParameter("Value", tableRelationTableFilterLine.Value);
        }

        public static Invocation ToInvocation(this Application application)
        {
            return new Invocation(
                "New-CBreezeApplication",
                new ScriptBlockParameter(
                    "Objects",
                    application.Tables.ToInvocation()
                        .Concat(application.Pages.ToInvocation())
                )
            );
        }

        public static Invocation ToInvocation(this Table table)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", table.ID),
                new SimpleParameter("Name", table.Name)
            };

            IEnumerable<ParameterBase> objectProperties = table
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = table
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    table.Fields.ToInvocation().Cast<Statement>()
                        .Concat(table.FieldGroups.ToInvocation().Cast<Statement>())
                        .Concat(table.Keys.ToInvocation().Cast<Statement>())
                        .Concat(table.Code.Variables.ToInvocation().Cast<Statement>())
                        .Concat(table.Code.Functions.ToInvocation().Cast<Statement>())
                        .Concat(table.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>())
                )
            };

            return new Invocation(
                "New-CBreezeTable",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects));
        }

        public static Invocation ToInvocation(this Page page)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", page.ID),
                new SimpleParameter("Name", page.Name)
            };

            IEnumerable<ParameterBase> objectProperties = page
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = page
                .Properties
                .Where(p => p.HasValue)
                .Where(p => p.GetType() != typeof(ActionListProperty))
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    page.Properties.ActionList.ToInvocation()
                )
            };

            return new Invocation(
                "New-CBreezePage",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects)
            );
        }

        public static IEnumerable<Invocation> ToInvocation(this Tables tables) => tables.Select(t => t.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this Pages pages) => pages.Select(p => p.ToInvocation());

        public static Invocation ToInvocation(this TableField field) => new Invocation($"New-CBreeze{field.Type}TableField", field.Parameters());

        public static IEnumerable<Invocation> ToInvocation(this TableKeys keys) => keys.Select(k => k.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this TableFieldGroups fieldGroups) => fieldGroups.Select(g => g.ToInvocation());

        public static Invocation ToInvocation(this TableFieldGroup fieldGroup) => new Invocation("New-CBreezeTableFieldGroup", fieldGroup.Parameters());

        public static IEnumerable<Invocation> ToInvocation(this ActionList actionList) => actionList.ToInvocation(0);

        public static IEnumerable<Invocation> ToInvocation(this IEnumerable<PageActionBase> actionList, int indentation)
        {
            return
                actionList
                    .Select((a, i) => new
                    {
                        Action = a,
                        Children = actionList.Skip(i + 1).TakeWhile(c => c.IndentationLevel > a.IndentationLevel).Where(c => c.IndentationLevel == a.IndentationLevel + 1)
                    })
                    .Where(o => o.Action.IndentationLevel == indentation)
                    .Select(o => o.Action.ToInvocation(o.Children));
        }

        public static Invocation ToInvocation(this PageActionBase pageActionBase, IEnumerable<PageActionBase> children)
        {
            switch (pageActionBase)
            {
                case PageActionContainer c:
                    return c.ToInvocation(children);
                case PageActionGroup g:
                    return g.ToInvocation(children);
                case PageAction a:
                    return a.ToInvocation();
                case PageActionSeparator s:
                    return s.ToInvocation();
                default:
                    return null;
            }
        }

        public static Invocation ToInvocation(this PageActionContainer pageActionContainer, IEnumerable<PageActionBase> children) => new Invocation("New-CBreezePageActionContainer", pageActionContainer.Parameters(children));

        public static Invocation ToInvocation(this PageActionGroup pageActionGroup, IEnumerable<PageActionBase> children) => new Invocation("New-CBreezePageActionGroup", pageActionGroup.Parameters(children));

        public static Invocation ToInvocation(this PageAction pageAction) => new Invocation("New-CBreezePageAction", pageAction.Parameters());

        public static Invocation ToInvocation(this PageActionSeparator pageActionSeparator) => new Invocation("New-CBreezePageActionSeparator"); // FIXME: parameters

        public static IEnumerable<Invocation> ToInvocation(this Variables variables) => variables.Select(v => v.ToInvocation());

        public static Invocation ToInvocation(this Variable variable) => new Invocation($"New-CBreeze{variable.GetType().Name}", variable.Parameters());

        public static Invocation ToInvocation(this CalcFormula calcFormula)
        {
            return new Invocation("New-CBreezeCalcFormula",
                new SwitchParameter(calcFormula.Method.ToString(), true),
                new SimpleParameter("TableName", calcFormula.TableName),
                new SimpleParameter("FieldName", calcFormula.FieldName),
                new SwitchParameter("ReverseSign", calcFormula.ReverseSign),
                new ScriptBlockParameter("Filters", calcFormula.TableFilter.ToInvocations()))
            { SuppressTrailingNewLine = true };
        }

        public static Invocation ToInvocation(this Permission permission)
        {
            return new Invocation("New-CBreezePermission",
                new SimpleParameter("TableID", permission.TableID),
                new SwitchParameter("Read", permission.ReadPermission),
                new SwitchParameter("Insert", permission.InsertPermission),
                new SwitchParameter("Modify", permission.ModifyPermission),
                new SwitchParameter("Delete", permission.DeletePermission))
            { SuppressTrailingNewLine = true };
        }

        public static Invocation ToInvocation(this CalcFormulaTableFilterLine calcFormulaTableFilterLine)
        {
            return new Invocation("New-CBreezeCalcFormulaFilter", calcFormulaTableFilterLine.Parameters());
        }

        public static Invocation ToInvocation(this AccessByPermission accessByPermission)
        {
            return new Invocation("New-CBreezeAccessByPermission",
                new SimpleParameter("ObjectType", accessByPermission.ObjectType),
                new SimpleParameter("ObjectID", accessByPermission.ObjectID),
                new SwitchParameter("Read", accessByPermission.Read),
                new SwitchParameter("Insert", accessByPermission.Insert),
                new SwitchParameter("Modify", accessByPermission.Modify),
                new SwitchParameter("Delete", accessByPermission.Delete),
                new SwitchParameter("Execute", accessByPermission.Execute))
            { SuppressTrailingNewLine = true };
        }

        public static Invocation ToInvocation(this TableKey key)
        {
            var fields = new[] {
                new SimpleParameter("Enabled", key.Enabled),
                new SimpleParameter("Fields", key.Fields)
            };

            var properties = key
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            return new Invocation("New-CBreezeTableKey", fields.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this Functions functions) => functions.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this Function function) => new Invocation($"New-CBreeze{FunctionType(function)}", function.Parameters());

        public static Invocation ToInvocation(this Parameter parameter) => new Invocation($"New-CBreeze{parameter.Type}Parameter", parameter.Parameters());

        public static Invocation ToInvocation(this TableRelationLine tableRelationLine) => new Invocation("New-CBreezeTableRelation", tableRelationLine.Parameters());

        public static Invocation ToInvocation(this TableRelationCondition condition)
        {
            return new Invocation("New-CBreezeTableRelationCondition", condition.Parameters());
        }

        public static Invocation ToInvocation(this TableRelationTableFilterLine tableRelationFilterLine)
        {
            return new Invocation("New-CBreezeTableRelationFilter", tableRelationFilterLine.Parameters());
        }

        public static IEnumerable<Literal> ToInvocation(this CodeLines codeLines) => codeLines.Select(c => new Literal(c));

        public static IEnumerable<Invocation> ToInvocations(this Permissions permissions) => permissions.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this CalcFormulaTableFilter calcFormulaTableFilter) => calcFormulaTableFilter.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelation tableRelation) => tableRelation.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelationConditions conditions) => conditions.Select(c => c.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelationTableFilter filter) => filter.Select(l => l.ToInvocation());

        public static IEnumerable<ParameterBase> ToParameters(this Property property)
        {
            switch (property)
            {
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

                default:
                    yield return new SimpleParameter(property.Name, property.GetValue());
                    break;
            }
        }
    }
}