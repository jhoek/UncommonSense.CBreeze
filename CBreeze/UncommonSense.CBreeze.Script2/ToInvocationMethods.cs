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
                new ScriptBlockParameter("Fields", table.Fields.ToInvocation())
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

            return new Invocation($"New-CBreeze{field.Type}Field", signature.Concat(properties));
        }
    }
}