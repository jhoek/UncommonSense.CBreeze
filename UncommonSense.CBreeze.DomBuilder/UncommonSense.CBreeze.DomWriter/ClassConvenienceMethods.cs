using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public static class ClassConvenienceMethods
    {
        public static Field AddField(this Class @class, string name, string typeName)
        {
            var field = new Field(name, typeName);
            @class.Fields.Add(field);
            return field;
        }

        public static Constructor AddConstructor(this Class @class)
        {
            var constructor = new Constructor(@class);
            @class.Constructors.Add(constructor);
            return constructor;
        }

        public static ClassMethod AddMethod(this Class @class, string name, string returnTypeName)
        {
            var method = new ClassMethod(name, returnTypeName);
            @class.Methods.Add(method);
            return method;
        }

        public static ClassProperty AddProperty(this Class @class, string name, string typeName)
        {
            var property = new ClassProperty(name, typeName);
            @class.Properties.Add(property);
            return property;
        }
    }
}
