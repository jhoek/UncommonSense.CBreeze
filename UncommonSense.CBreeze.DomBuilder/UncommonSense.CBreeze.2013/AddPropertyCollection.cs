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
        public static PropertyCollection AddPropertyCollection(this ObjectModel objectModel, string name)
        {
            var propertyCollection = new PropertyCollection(name);
            return objectModel.Elements.Add(propertyCollection);
        }
    }
}
