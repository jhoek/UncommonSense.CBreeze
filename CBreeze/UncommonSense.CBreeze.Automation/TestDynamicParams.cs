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
        protected DynamicParameter<Core.Application> application = new DynamicParameter<Core.Application>("Application", true);
        protected DynamicParameter<IEnumerable<int>> range = new DynamicParameter<IEnumerable<int>>("Range", true);
        protected DynamicParameter<ObjectType?> objectType = new DynamicParameter<ObjectType?>("Type", true);
        protected DynamicParameter<int> dynamic = new DynamicParameter<int>("Dynamic");

        protected override void ProcessRecord()
        {
            WriteObject(dynamic.Value);
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                yield return objectType.RuntimeDefinedParameter;
                yield return application.RuntimeDefinedParameter;
                yield return range.RuntimeDefinedParameter;

                if (objectType.Value.GetValueOrDefault(ObjectType.Page) == ObjectType.Table)
                    yield return dynamic.RuntimeDefinedParameter;
            }
        }
    }
}
