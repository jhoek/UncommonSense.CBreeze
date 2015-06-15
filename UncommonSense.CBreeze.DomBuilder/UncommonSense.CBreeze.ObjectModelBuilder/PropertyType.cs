using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class PropertyType : ObjectModelElement
    {
        public PropertyType(string name, string innerTypeName)
            : base(name)
        {
            InnerTypeName = innerTypeName;
        }

        public string InnerTypeName
        {
            get;
            internal set;
        }

        public string HasValueExpr
        {
            get;
            set;
        }
    }
}
