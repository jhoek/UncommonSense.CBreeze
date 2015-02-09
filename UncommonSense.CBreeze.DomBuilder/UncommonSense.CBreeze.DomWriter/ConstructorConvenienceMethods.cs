using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public static class ConstructorConvenienceMethods
    {
        public static MethodParameter AddParameter(this Constructor constructor, string name, string typeName)
        {
            var methodParameter = new MethodParameter(name, typeName);
            constructor.Parameters.Add(methodParameter);
            return methodParameter;
        }
    }
}
