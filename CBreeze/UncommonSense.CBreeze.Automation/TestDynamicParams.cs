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
    public class TestDynamicParams : Cmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            Console.WriteLine("03.12.15 10:30");
            Console.WriteLine(InputObject.BaseObject.GetType().Name);
        }

        public object GetDynamicParameters()
        {
            var dynamicParameters = new RuntimeDefinedParameterDictionary();

            if (InputObject != null)
            {
                var parameterAttribute = new ParameterAttribute();
                var attributes = new System.Collections.ObjectModel.Collection<Attribute>() { parameterAttribute };

                int dummy;

                if (int.TryParse(InputObject.BaseObject.ToString(), out dummy))
                {
                    var @int = new RuntimeDefinedParameter("Int", typeof(string), attributes);
                    dynamicParameters.Add("Int", @int);
                }
                else
                {
                    var @string = new RuntimeDefinedParameter("String", typeof(string), attributes);
                    dynamicParameters.Add("String", @string);
                }
            }

            return dynamicParameters;
        }
    }
}
