using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public static class MethodConvenienceMethods
    {
        public static MethodParameter AddParameter(this Method method, string name, string typeName)
        {
            var methodParameter = new MethodParameter(name, typeName);
            method.Parameters.Add(methodParameter);
            return methodParameter;
        }
    }
}
