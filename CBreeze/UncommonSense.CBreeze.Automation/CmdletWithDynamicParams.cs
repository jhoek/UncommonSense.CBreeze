using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;

namespace UncommonSense.CBreeze.Automation
{
    public abstract class CmdletWithDynamicParams : Cmdlet, IDynamicParameters
    {
        public object GetDynamicParameters()
        {
            foreach (var unboundArgument in UnboundArguments)
            {
                Debug.Print("{0} = {1}", unboundArgument.Key, unboundArgument.Value);
            }

            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();

            foreach (var dynamicParameter in DynamicParameters)
            {
                runtimeDefinedParameterDictionary.Add(dynamicParameter.Name, dynamicParameter);
            }

            return runtimeDefinedParameterDictionary;
        }

        public abstract IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get;
        }

        protected object TryGetProperty(object instance, string fieldName)
        {
            const BindingFlags BindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

            if (instance == null)
                return null;

            if (string.IsNullOrEmpty(fieldName))
                return null;

            var propertyInfo = instance.GetType().GetProperty(fieldName, BindingFlags);

            if (propertyInfo != null)
            {
                try
                {
                    return propertyInfo.GetValue(instance, null);
                }
                catch
                {
                }
            }

            var fieldInfo = instance.GetType().GetField(fieldName, BindingFlags);

            if (fieldInfo != null)
            {
                try
                {
                    return fieldInfo.GetValue(instance);
                }
                catch
                {
                }
            }

            return null;
        }

        protected Dictionary<string, object> UnboundArguments
        {
            get
            {
                var context = TryGetProperty(this, "Context");
                var processor = TryGetProperty(context, "CurrentCommandProcessor");
                var parameterBinder = TryGetProperty(processor, "CmdletParameterBinderController");
                var args = TryGetProperty(parameterBinder, "UnboundArguments") as IEnumerable;
                var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                if (args != null)
                {
                    var currentParameterName = string.Empty;
                    var i = 0;

                    foreach (var arg in args)
                    {
                        var isParameterName = TryGetProperty(arg, "ParameterNameSpecified");

                        if (isParameterName != null && true.Equals(isParameterName))
                        {
                            var parameterName = TryGetProperty(arg, "ParameterName");

                            if (parameterName != null)
                            {
                                currentParameterName = parameterName.ToString();

                                if (result.ContainsKey(currentParameterName))
                                    result[currentParameterName] = null;
                                else
                                    result.Add(currentParameterName, null);

                                continue;
                            }
                        }

                        var parameterValue = TryGetProperty(arg, "ArgumentValue");

                        if (string.IsNullOrEmpty(currentParameterName))
                        {
                            result.Add("unbound_" + (i++), parameterValue);
                        }
                        else
                        {
                            result[currentParameterName] = parameterValue;
                        }

                        currentParameterName = null;
                    }
                }

                return result;
            }
        }
    }
}
