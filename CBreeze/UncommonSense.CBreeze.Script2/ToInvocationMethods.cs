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
                "Application",
                new ScriptBlockParameter("Objects", true, application.Tables.ToInvocation()));
        }

        public static Invocation ToInvocation(this Table table)
        {
            return new Invocation(
                "New-CBreezeTable",
                "Table",

                //                new[] {
                //new SimpleParameter("ID", true, table.ID),
                //new SimpleParameter("Name", true, table.Name) }.Concat(
                table
                    .ObjectProperties
                    .Where(p => p.HasValue)
                    .Select(p => new SimpleParameter(p.Name, false, table.ObjectProperties[p.Name])));
        }

        public static IEnumerable<Invocation> ToInvocation(this Tables tables) => tables.Select(t => t.ToInvocation());
    }
}