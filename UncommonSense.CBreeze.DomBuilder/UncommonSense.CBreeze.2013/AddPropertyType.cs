using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze
{
    public static partial class ExtensionMethods
    {
        public static PropertyType AddPropertyType(this ObjectModel objectModel, string name, string innerTypeName)
        {
            var propertyType = new PropertyType(name, innerTypeName);
            return objectModel.Elements.Add(propertyType);
        }
    }
}
