using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Key;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
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
                    table.Fields.ToInvocations().Cast<Statement>()
                        .Concat(table.FieldGroups.ToInvocations().Cast<Statement>())
                        .Concat(table.Keys.ToInvocations().Cast<Statement>())
                        .Concat(table.Code.Variables.ToInvocations().Cast<Statement>())
                        .Concat(table.Code.Functions.ToInvocations().Cast<Statement>())
                        .Concat(table.Code.Events.ToInvocations().Cast<Statement>())
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

        public static IEnumerable<Invocation> ToInvocations(this TableFields fields) => fields.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this TableField field) => new Invocation($"New-CBreeze{field.Type}TableField", field.ToParameters());

        public static IEnumerable<Invocation> ToInvocations(this TableKeys keys) => keys.Select(k => k.ToInvocation());

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

        public static IEnumerable<Invocation> ToInvocations(this TableFieldGroups fieldGroups) => fieldGroups.Select(g => g.ToInvocation());

        public static Invocation ToInvocation(this TableFieldGroup fieldGroup) => new Invocation("New-CBreezeTableFieldGroup", fieldGroup.ToParameters());
    }
}
