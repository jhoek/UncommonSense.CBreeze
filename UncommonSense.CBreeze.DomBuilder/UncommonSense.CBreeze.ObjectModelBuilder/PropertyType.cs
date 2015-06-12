using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class PropertyType : ObjectModelElement
    {
        public PropertyType(string name, string innerValue)
            : base(name)
        {
            InnerValue = innerValue;
        }

        public string InnerValue
        {
            get;
            internal set;
        }
    }
}
