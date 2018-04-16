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
        public static Invocation ToInvocation(this Application application)
        {
            return new Invocation(
                "New-CBreezeApplication",
                new ScriptBlockParameter(
                    "Objects",
                    application.Tables.ToInvocation()
                        .Concat(application.Pages.ToInvocation())
                        .Concat(application.Reports.ToInvocation())
                        .Concat(application.Queries.ToInvocation())
                )
            );
        }

        public static IEnumerable<Invocation> ToInvocation(this Tables tables) => tables.Select(t => t.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this Pages pages) => pages.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this Reports reports) => reports.Select(r => r.ToInvocation());

        public static IEnumerable<Invocation> ToInvocation(this Queries queries) => queries.Select(q => q.ToInvocation());
    }
}
