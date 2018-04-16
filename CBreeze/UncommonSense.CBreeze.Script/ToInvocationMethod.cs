using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
        public static IEnumerable<Invocation> ToInvocation(this TableFields fields) => fields.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this Query query)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", query.ID),
                new SimpleParameter("Name", query.Name)
            };

            IEnumerable<ParameterBase> objectProperties = query
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = query
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    query.Properties.OrderBy.ToInvocations()
                        .Concat(query.Elements.ToInvocations())
                )
            };

            return new Invocation(
                "New-CBreezeQuery",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects)
            );
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
                        .Concat(page.Properties.SourceTableView.TableFilter.ToInvocations())
                        .Concat(page.Controls.ToInvocation().Cast<Statement>())
                        .Concat(page.Code.Variables.ToInvocation().Cast<Statement>())
                        .Concat(page.Code.Functions.ToInvocation().Cast<Statement>())
                        .Concat(page.Code.Events.ToInvocation().Cast<Statement>())
                        .Concat(page.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>())
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

        public static Invocation ToInvocation(this TableField field) => new Invocation($"New-CBreeze{field.Type}TableField", field.ToParameters());

        public static IEnumerable<Invocation> ToInvocation(this TableKeys keys) => keys.Select(k => k.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this TableFieldGroups fieldGroups) => fieldGroups.Select(g => g.ToInvocation());

        public static Invocation ToInvocation(this TableFieldGroup fieldGroup) => new Invocation("New-CBreezeTableFieldGroup", fieldGroup.ToParameters());

        public static IEnumerable<Invocation> ToInvocation(this PageControls pageControls) => pageControls.Where(c => c.IndentationLevel.GetValueOrDefault(0) == 0).Select(c => c.ToInvocation());

        public static Invocation ToInvocation(this PageControlBase pageControl)
        {
            switch (pageControl)
            {
                case PageControlContainer c:
                    return new Invocation("New-CBreezePageControlContainer", c.ToParameters());

                case PageControlGroup g:
                    return new Invocation("New-CBreezePageControlGroup", g.ToParameters());

                case PageControlPart p:
                    return new Invocation("New-CBreezePageControlPart", p.ToParameters());

                case PageControl f:
                    return new Invocation("New-CBreezePageControl", f.ToParameters());

                default:
                    throw new ArgumentOutOfRangeException("pageControl");
            }
        }

        public static IEnumerable<Invocation> ToInvocation(this ActionList actionList) => actionList.Where(a => a.IndentationLevel.GetValueOrDefault(0) == 0).Select(a => a.ToInvocation());

        public static Invocation ToInvocation(this PageActionBase pageActionBase)
        {
            switch (pageActionBase)
            {
                case PageActionContainer c:
                    return new Invocation("New-CBreezePageActionContainer", c.ToParameters());

                case PageActionGroup g:
                    return new Invocation("New-CBreezePageActionGroup", g.ToParameters());

                case PageAction a:
                    return new Invocation("New-CBreezePageAction", a.ToParameters());

                case PageActionSeparator s:
                    return new Invocation("New-CBreezePageActionSeparator", s.ToParameters());

                default:
                    return null;
            }
        }

        public static IEnumerable<Invocation> ToInvocation(this Parameters parameters) => parameters.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this Variables variables) => variables.Select(v => v.ToInvocation());

        public static Invocation ToInvocation(this Variable variable) => new Invocation($"New-CBreeze{variable.GetType().Name}", variable.ToParameters());

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
            return new Invocation("New-CBreezeCalcFormulaFilter", calcFormulaTableFilterLine.ToParameters());
        }

#if NAV2015
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
#endif

        public static Invocation ToInvocation(this TableKey key)
        {
            var fields = new ParameterBase[] {
                new SwitchParameter("Enabled", key.Enabled),
                new SimpleParameter("Fields", key.Fields)
            };

            var properties = key
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            return new Invocation("New-CBreezeTableKey", fields.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this Events events) => events.Select(e => e.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this Functions functions) => functions.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this Function function) => new Invocation($"New-CBreeze{function.FunctionType()}", function.ToParameters());

        public static Invocation ToInvocation(this Event @event) => new Invocation("New-CBreezeEvent", @event.ToParameters());

        public static Invocation ToInvocation(this Parameter parameter) => new Invocation($"New-CBreeze{parameter.Type}Parameter", parameter.ToParameters());

        public static Invocation ToInvocation(this TableRelationLine tableRelationLine) => new Invocation("New-CBreezeTableRelation", tableRelationLine.ToParameters());

        public static Invocation ToInvocation(this TableRelationCondition condition)
        {
            return new Invocation("New-CBreezeTableRelationCondition", condition.ToParameters());
        }

        public static Invocation ToInvocation(this TableRelationTableFilterLine tableRelationFilterLine)
        {
            return new Invocation("New-CBreezeTableRelationFilter", tableRelationFilterLine.ToParameters());
        }

        public static Invocation ToInvocation(this RunObjectLinkLine runObjectLinkLine) => new Invocation("New-CBreezeRunObjectLink", runObjectLinkLine.ToParameters());

        public static Invocation ToInvocation(this TableFilterLine tableFilterLine) => new Invocation("New-CBreezeFilter", tableFilterLine.ToParameters());

        public static Invocation ToInvocation(this QueryOrderByLine queryOrderByLine) => new Invocation("New-CBreezeOrderBy", queryOrderByLine.ToParameters());

        public static Invocation ToInvocation(this QueryElement queryElement) => new Invocation($"New-CBreeze{queryElement.Type}QueryElement", queryElement.ToParameters());

        public static IEnumerable<Literal> ToInvocation(this CodeLines codeLines) => codeLines.Select(c => new Literal(c));

        public static IEnumerable<Invocation> ToInvocations(this Permissions permissions) => permissions.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this CalcFormulaTableFilter calcFormulaTableFilter) => calcFormulaTableFilter.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelation tableRelation) => tableRelation.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelationConditions conditions) => conditions.Select(c => c.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelationTableFilter filter) => filter.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this RunObjectLink runObjectLink) => runObjectLink.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableFilter tableFilter) => tableFilter.Select(f => f.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this QueryOrderByLines orderByLines) => orderByLines.Select(o => o.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this QueryElements queryElements) => queryElements.Select(e => e.ToInvocation());
    }
}