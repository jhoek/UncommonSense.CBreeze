using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

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
                    table.Fields.ToInvocation().Cast<Statement>()
                        .Concat(table.FieldGroups.ToInvocation().Cast<Statement>())
                        .Concat(table.Keys.ToInvocation().Cast<Statement>())
                        .Concat(table.Code.Variables.ToInvocation().Cast<Statement>())
                        .Concat(table.Code.Functions.ToInvocation().Cast<Statement>())
                        .Concat(table.Code.Events.ToInvocation().Cast<Statement>())
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
    }
}
