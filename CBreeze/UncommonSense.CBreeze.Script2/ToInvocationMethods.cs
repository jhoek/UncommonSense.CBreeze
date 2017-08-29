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
                new SimpleParameter("ID", true, table.ID),
                new SimpleParameter("Name", true, table.Name),
                new SimpleParameter("DateTime", false, table.ObjectProperties.DateTime?.ToShortDateString() ?? null));
        }

        public static IEnumerable<Invocation> ToInvocation(this Tables tables) => tables.Select(t => t.ToInvocation());
    }
}