using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    public class DynamicParameter<T>
    {
        public DynamicParameter(string name, bool mandatory, T minRange, T maxRange)
            : this(name, mandatory)
        {
            var validateRangeAttribute = new ValidateRangeAttribute(minRange, maxRange);
            RuntimeDefinedParameter.Attributes.Add(validateRangeAttribute);
        }

        public DynamicParameter(string name, bool mandatory, string parameterSetName)
        {
            var attributes = new Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute();
            parameterAttribute.Mandatory = mandatory;
            parameterAttribute.ParameterSetName = parameterSetName;
            attributes.Add(parameterAttribute);

            RuntimeDefinedParameter = new RuntimeDefinedParameter(name, typeof(T), attributes);
        }

        public DynamicParameter(string name, bool mandatory)
            : this(name, mandatory, null)
        {
        }

        public RuntimeDefinedParameter RuntimeDefinedParameter
        {
            get;
            protected set;
        }

        public T Value
        {
            get
            {
                return (T)RuntimeDefinedParameter.Value;
            }
        }
    }
}
