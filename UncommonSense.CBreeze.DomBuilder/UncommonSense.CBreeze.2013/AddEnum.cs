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
        public static Enumeration AddEnum(this ObjectModel objectModel, string name, params string[] values)
        {
            var enumeration = new Enumeration(name, values);
            return objectModel.Elements.Add(enumeration);
        }
    }
}
