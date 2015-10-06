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
        public DynamicParameter(string name)
            : this(name, false)
        {
        }

        public DynamicParameter(string name, bool mandatory)
        {
            var attributes = new Collection<Attribute>();

            var parameterAttribute = new ParameterAttribute();
            parameterAttribute.Mandatory = mandatory;
            attributes.Add(parameterAttribute);

            RuntimeDefinedParameter = new RuntimeDefinedParameter(name, typeof(T), attributes);
        }

        public DynamicParameter(string name, T minRange, T maxRange)
            : this(name, false, minRange, maxRange)
        {
        }

        public DynamicParameter(string name, bool mandatory, T minRange, T maxRange)
            : this(name, mandatory)
        {
            var validateRangeAttribute = new ValidateRangeAttribute(minRange, maxRange);
            RuntimeDefinedParameter.Attributes.Add(validateRangeAttribute);
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
