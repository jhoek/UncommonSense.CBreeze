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
        public static Invocation ToInvocation(this XmlPort xmlPort)
        {
            IEnumerable<ParameterBase> signature = new[] {
                new SimpleParameter("ID", xmlPort.ID),
                new SimpleParameter("Name", xmlPort.Name)
            };

            IEnumerable<ParameterBase> objectProperties = xmlPort
                .ObjectProperties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> properties = xmlPort
                .Properties
                .Where(p => p.HasValue)
                .SelectMany(p => p.ToParameters());

            IEnumerable<ParameterBase> subObjects = new[] {
                new ScriptBlockParameter(
                    "SubObjects",
                    xmlPort.Properties.Namespaces.ToInvocation().Cast<Statement>()
                )
            };

            return new Invocation(
                "New-CBreezeXmlPort",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
            );
        }

        public static IEnumerable<Invocation> ToInvocation(this XmlPortNamespaces xmlPortNamespaces) => xmlPortNamespaces.Select(n => n.ToInvocation());

        public static Invocation ToInvocation(this XmlPortNamespace xmlPortNamespace) => new Invocation("Set-CBreezeXmlPortNamespace", xmlPortNamespace.ToParameters());
    }
}
