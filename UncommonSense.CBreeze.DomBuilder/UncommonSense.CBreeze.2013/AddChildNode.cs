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
        public static Item AddChildNode(this Item item, string typeName, string name = null)
        {
            var childNode = new ChildNode(typeName, name ?? typeName);
            item.Attributes.Add(childNode);
            return item;
        }
    }
}
