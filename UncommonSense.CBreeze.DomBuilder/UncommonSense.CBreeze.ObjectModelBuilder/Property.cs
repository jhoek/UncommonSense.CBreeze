using System;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Property
    {
        public Property(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }

        public string Name
        {
            get;
            internal set;
        }

        public string TypeName
        {
            get;
            internal set;
        }

        public PropertyCollection Collection
        {
            get;
            internal set;
        }
    }
}

