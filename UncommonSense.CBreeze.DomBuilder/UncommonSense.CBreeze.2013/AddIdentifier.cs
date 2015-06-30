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
        public static Item AddIdentifier(this Item item, string typeName, string name = null)
        {
            var identifier = new Identifier(typeName, name ?? typeName);
            item.Attributes.Add(identifier);
            return item;
        }
    }
}
