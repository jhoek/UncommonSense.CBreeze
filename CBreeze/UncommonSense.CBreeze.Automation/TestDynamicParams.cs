using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsDiagnostic.Test, "DynamicParams")]
    public class TestDynamicParams : CmdletWithDynamicParams
    {
        public TestDynamicParams()
        {
            Application = new DynamicParameter<Core.Application>("Application", true);
            Range = new DynamicParameter<IEnumerable<int>>("Range", true);
            Dynamic = new DynamicParameter<int>("Dynamic", "Foo");
        }

        protected DynamicParameter<Application> Application
        {
            get;
            set;
        }

        protected DynamicParameter<IEnumerable<int>> Range
        {
            get;
            set;
        }

        protected DynamicParameter<int> Dynamic
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            WriteObject(Dynamic.Value);
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                yield return Application.RuntimeDefinedParameter;
                yield return Range.RuntimeDefinedParameter;
                yield return Dynamic.RuntimeDefinedParameter;
            }
        }
    }
}
