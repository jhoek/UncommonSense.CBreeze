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
        protected DynamicParameter<string> @string = new DynamicParameter<string>("String");
        protected DynamicParameter<string> @int = new DynamicParameter<string>("Int");

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            Console.WriteLine(InputObject.BaseObject.GetType().Name);
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                if (InputObject.BaseObject is int)
                {
                    Console.WriteLine("InputObject is an int.");
                    yield return @int.RuntimeDefinedParameter;
                }
                if (InputObject.BaseObject is string)
                {
                    Console.WriteLine("InputObject is a string.");
                    yield return @string.RuntimeDefinedParameter;
                }
            }
        }
    }
}
