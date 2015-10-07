using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    //[Cmdlet("Test", "DynamicParameter")]
    public class TestDynamicParameter : PSCmdlet, IDynamicParameters
    {
        private RuntimeDefinedParameter type = new RuntimeDefinedParameter("Type", typeof(int), new Collection<Attribute> { new ParameterAttribute() });
        private RuntimeDefinedParameter one = new RuntimeDefinedParameter("One", typeof(int), new Collection<Attribute> { new ParameterAttribute() });
        private RuntimeDefinedParameter two = new RuntimeDefinedParameter("Two", typeof(int), new Collection<Attribute> { new ParameterAttribute() });

        public object GetDynamicParameters()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Type"))
            {
                var myValue = MyInvocation.BoundParameters["Type"].ToString();
            }

            var parameters = new RuntimeDefinedParameterDictionary();
            parameters.Add("Type", type);

            if (type != null)
                if (type.Value != null)
                {
                    {
                        if ((int)type.Value == 1)
                            parameters.Add("One", one);

                        if ((int)type.Value == 2)
                            parameters.Add("Two", two);
                    }
                }

            return parameters;
        }
    }
}
