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
            : this(name, false, null)
        {
        }

        public DynamicParameter(string name, params string[] parameterSetNames)
            : this(name, false, parameterSetNames)
        {
        }

        public DynamicParameter(string name, bool mandatory, params string[] parameterSetNames)
        {
            var attributes = new Collection<Attribute>();

            if (parameterSetNames == null)
                parameterSetNames = new string[] { null };
            if (parameterSetNames.Length == 0)
                parameterSetNames = new string[] { null };

            foreach (var parameterSetName in parameterSetNames)
            {
                var parameterAttribute = new ParameterAttribute();
                parameterAttribute.Mandatory = mandatory;
                parameterAttribute.ParameterSetName = parameterSetName;
                attributes.Add(parameterAttribute);
            }

            RuntimeDefinedParameter = new RuntimeDefinedParameter(name, typeof(T), attributes);
        }

        public DynamicParameter(string name, int minRange, int maxRange, params string[] parameterSetNames)
            : this(name, false, minRange, maxRange, parameterSetNames)
        {
        }

        public DynamicParameter(string name, bool mandatory, int minRange, int maxRange, params string[] parameterSetNames)
            : this(name, mandatory, parameterSetNames)
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
                if (RuntimeDefinedParameter.Value == null)
                    return default(T);

                return (T)RuntimeDefinedParameter.Value;
            }
        }
    }
}
