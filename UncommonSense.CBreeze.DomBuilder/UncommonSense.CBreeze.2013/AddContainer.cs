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
        public static Container AddContainer(this ObjectModel objectModel, string itemTypeName, string name = null)
        {
            var container = new Container(itemTypeName, name ?? string.Format("{0}s", itemTypeName));
            return objectModel.Elements.Add(container);
        }
    }
}
