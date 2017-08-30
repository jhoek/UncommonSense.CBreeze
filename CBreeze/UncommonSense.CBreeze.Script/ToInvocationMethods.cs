using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class ToInvocationMethods
    {
        public static Invocation ToInvocation(this Application application)
        {
            return new Invocation(
                "New-CBreezeApplication",
                new ScriptBlockParameter("Objects", application.Tables.ToInvocation()));
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
                    table.Fields.ToInvocation()
                    .Concat(table.Keys.ToInvocation())
                    .Concat(table.Code.Functions.ToInvocation()))
            };

            return new Invocation(
                "New-CBreezeTable",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects));
        }

        public static IEnumerable<Invocation> ToInvocation(this Tables tables) => tables.Select(t => t.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this TableFields fields) => fields.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this TableField field)
        {
            var signature = new[] {
                new SimpleParameter("ID", field.ID),
                new SimpleParameter("Name", field.Name)
            };

            var properties = field
                .AllProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            return new Invocation($"New-CBreeze{field.Type}TableField", signature.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this TableKeys keys) => keys.Select(k => k.ToInvocation());

        public static Invocation ToInvocation(this CalcFormula calcFormula)
        {
            return new Invocation("New-CBreezeCalcFormula",
                new SwitchParameter(calcFormula.Method.ToString(), true),
                new SimpleParameter("TableName", calcFormula.TableName),
                new SimpleParameter("FieldName", calcFormula.FieldName)
                )
            { SuppressTrailingNewLine = true }; // FIXME
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
            { SuppressTrailingNewLine = true }; // FIXME
        }

        public static Invocation ToInvocation(this TableKey key)
        {
            var fields = new[] {
                new SimpleParameter("Fields", key.Fields)
            };

            var properties = key
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            return new Invocation("New-CBreezeTableKey", fields.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this Functions functions) => functions.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this Function function)
        {
            return new Invocation(
                $"New-CBreeze{FunctionType(function)}",
                new SimpleParameter("ID", function.ID),
                new SimpleParameter("Name", function.Name),
                new SimpleParameter("Local", function.Local),
                new SimpleParameter("ReturnValueName", function.ReturnValue.Name),
                new SimpleParameter("ReturnValueType", function.ReturnValue.Type),
                new SimpleParameter("ReturnValueDataLength", function.ReturnValue.DataLength),
                new SimpleParameter("ReturnValueDimensions", function.ReturnValue.Dimensions)
                );
        }

        public static IEnumerable<ParameterBase> ToParameters(this Property property)
        {
            switch (property)
            {
                case TriggerProperty t:
                    yield return new ScriptBlockParameter(t.Name, new Invocation("# FIXME"));
                    yield break;

                case TableRelationProperty t:
                    yield return new ScriptBlockParameter("SubObjects", new Invocation("# FIXME"));
                    yield break;

                case CalcFormulaProperty c:
                    yield return new SimpleParameter(c.Name, c.Value.ToInvocation());
                    yield break;

                case AccessByPermissionProperty a:
                    yield return new SimpleParameter(a.Name, a.Value.ToInvocation());
                    yield break;

                case DecimalPlacesProperty d:
                    yield return new SimpleParameter("DecimalPlacesAtLeast", d.Value.AtLeast);
                    yield return new SimpleParameter("DecimalPlacesAtMost", d.Value.AtMost);
                    yield break;

                default:
                    yield return new SimpleParameter(property.Name, property.GetValue());
                    yield break;
            }
        }

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
    }
}