using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code;
using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Parameter;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Field.Properties;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
        public static IEnumerable<Invocation> ToInvocations(this Parameters parameters) => parameters.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this Variables variables) => variables.Select(v => v.ToInvocation());

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

        public static IEnumerable<Invocation> ToInvocations(this Events events) => events.Select(e => e.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this Functions functions) => functions.Select(f => f.ToInvocation());

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

        public static IEnumerable<Literal> ToInvocation(this CodeLines codeLines) => codeLines.Select(c => new Literal(c));

        public static IEnumerable<Invocation> ToInvocations(this Permissions permissions) => permissions.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this CalcFormulaTableFilter calcFormulaTableFilter) => calcFormulaTableFilter.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelation tableRelation) => tableRelation.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelationConditions conditions) => conditions.Select(c => c.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableRelationTableFilter filter) => filter.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this RunObjectLink runObjectLink) => runObjectLink.Select(l => l.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this TableFilter tableFilter) => tableFilter.Select(f => f.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this LinkFields linkFields) => linkFields.Select(l=> l.ToInvocation());

        public static Invocation ToInvocation(this LinkField linkField) => new Invocation("New-CBreezeXmlPortLink", linkField.ToParameters());
    }
}