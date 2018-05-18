using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToInvocationMethod
    {
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

        public static IEnumerable<Invocation> ToInvocations(this QueryElements queryElements) => queryElements.Where(e => e.IndentationLevel.GetValueOrDefault(0) == 0).Select(e => e.ToInvocation());

        public static Invocation ToInvocation(this QueryElement queryElement) => new Invocation($"New-CBreeze{queryElement.Type}QueryElement", queryElement.ToParameters());

        public static IEnumerable<Invocation> ToInvocations(this QueryOrderByLines orderByLines) => orderByLines.Select(o => o.ToInvocation());

        public static Invocation ToInvocation(this QueryOrderByLine queryOrderByLine) => new Invocation("New-CBreezeOrderBy", queryOrderByLine.ToParameters());

        public static Invocation ToInvocation(this QueryDataItemLinkLine queryDataItemLinkLine) => new Invocation("New-CBreezeQueryLink", queryDataItemLinkLine.ToParameters());
    }
}
