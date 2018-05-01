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
                    xmlPort.Nodes.ToInvocation().Cast<Statement>()
                        .Concat(xmlPort.Code.Variables.ToInvocation().Cast<Statement>())
                        .Concat(xmlPort.Code.Functions.ToInvocation().Cast<Statement>())
                        .Concat(xmlPort.Code.Events.ToInvocation().Cast<Statement>())
                        .Concat(xmlPort.Code.Documentation.CodeLines.ToInvocation().Cast<Statement>())
                )
            };

            return new Invocation(
                "New-CBreezeXmlPort",
                signature
                    .Concat(objectProperties)
                    .Concat(properties)
                    .Concat(subObjects)
            );
        }

        public static IEnumerable<Invocation> ToInvocation(this XmlPortNodes xmlPortNodes) => xmlPortNodes.Where(n => n.IndentationLevel.GetValueOrDefault(0) == 0).Select(n => n.ToInvocation());

        public static Invocation ToInvocation(this XmlPortNode xmlPortNode) => new Invocation($"New-CBreezeXmlPort{xmlPortNode.SourceType}{xmlPortNode.NodeType}", xmlPortNode.ToParameters());
    }
}
