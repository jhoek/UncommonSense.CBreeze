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
        public static Item DeriveItem(this Item baseItem, string name, bool createContainer = false, string containerName = null)
        {
            return AddItem(baseItem.ObjectModel, name, baseItem.Name, false, createContainer, containerName);
        }

        public static Item AndDeriveItem(this Item item, string name, bool createContainer = false, string containerName = null)
        {
            return DeriveItem(item.BaseType, name, createContainer, containerName);
        }
    }
}
