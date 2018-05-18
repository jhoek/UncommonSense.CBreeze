using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.XmlPort;

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
                    application.Tables.ToInvocations()
                        .Concat(application.Pages.ToInvocations())
                        .Concat(application.Codeunits.ToInvocations())
                        .Concat(application.Reports.ToInvocations())
                        .Concat(application.Queries.ToInvocations())
                        .Concat(application.XmlPorts.ToInvocations())
                        .Concat(application.MenuSuites.ToInvocations())
                )
            );
        }

        public static IEnumerable<Invocation> ToInvocations(this Tables tables) => tables.Select(t => t.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this Pages pages) => pages.Select(p => p.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this Reports reports) => reports.Select(r => r.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this Queries queries) => queries.Select(q => q.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this Codeunits codeunits) => codeunits.Select(c => c.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this XmlPorts xmlPorts) => xmlPorts.Select(x => x.ToInvocation());

        public static IEnumerable<Invocation> ToInvocations(this MenuSuites menuSuites) => menuSuites.Select(m => m.ToInvocation());
    }
}
