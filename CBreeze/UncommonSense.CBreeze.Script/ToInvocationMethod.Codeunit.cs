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
        public static Invocation ToInvocation(this Codeunit codeunit)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", codeunit.ID),
                new SimpleParameter("Name", codeunit.Name)
            };

            IEnumerable<ParameterBase> objectProperties = codeunit
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = codeunit
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());                

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                        "SubObjects",
                        codeunit.Code.Variables.ToInvocations().Cast<Statement>()
                            .Concat(codeunit.Code.Functions.ToInvocations().Cast<Statement>())
                            .Concat(codeunit.Code.Events.ToInvocations().Cast<Statement>())
                            .Concat(codeunit.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>()))
            };

            return new Invocation(
                "New-CBreezeCodeunit",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects)  
            );
        }
    }
}
