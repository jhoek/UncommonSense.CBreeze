using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script2
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
                .Select(p => new SimpleParameter(p.Name, table.ObjectProperties[p.Name].GetValue()));

            IEnumerable<ParameterBase> properties = table
                .Properties
                .Where(p => p.HasValue)
                .Select(p => new SimpleParameter(p.Name, table.Properties[p.Name].GetValue()));

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    table.Fields.ToInvocation()
                    .Concat(table.Keys.ToInvocation())
                    .Concat(table.Code.Functions.ToInvocation())
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
                .Select(p => new SimpleParameter(p.Name, field.AllProperties[p.Name].GetValue()));

            return new Invocation($"New-CBreeze{field.Type}TableField", signature.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this TableKeys keys) => keys.Select(k => k.ToInvocation());

        public static Invocation ToInvocation(this TableKey key)
        {
            var fields = new[] {
                new SimpleParameter("Fields", key.Fields)
            };

            var properties = key
                .Properties
                .Where(p => p.HasValue)
                .Select(p => new SimpleParameter(p.Name, key.Properties[p.Name].GetValue()));

            return new Invocation("New-CBreezeTableKey", fields.Concat(properties));
        }

        public static IEnumerable<Invocation> ToInvocation(this Functions functions) => functions.Select(f => f.ToInvocation());

        public static Invocation ToInvocation(this Function function)
        {

        }
    }
}