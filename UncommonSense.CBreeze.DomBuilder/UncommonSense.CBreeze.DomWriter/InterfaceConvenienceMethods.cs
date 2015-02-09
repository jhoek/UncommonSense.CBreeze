using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public static class InterfaceConvenienceMethods
    {
        public static InterfaceMethod AddMethod(this Interface @interface, string name, string returnTypeName)
        {
            var method = new InterfaceMethod(name, returnTypeName);
            @interface.Methods.Add(method);
            return method;
        }

        public static InterfaceProperty AddProperty(this Interface @interface, string name, string typeName)
        {
            var property = new InterfaceProperty(name, typeName);
            @interface.Properties.Add(property);
            return property;
        }
    }
}
