using System;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Property : Attribute
    {
        public Property(string name, string typeName)
            : base(name, typeName)
        {
        }
    }
}

