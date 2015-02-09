using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
    public static class FluentExtensionMethods
    {
        public static Item MakeAbstract(this Item item)
        {
            item.Abstract = true;
            return item;
        }

        public static Item AutoCreateContainer(this Item item)
        {
            item.AutoCreateContainer = true;
            return item;
        }

        public static Item SetBaseItemName(this Item item, string baseItemName)
        {
            item.BaseItemName = baseItemName;
            return item;
        }

        public static Item WithAttribute(this Item item, string typeName, string name = null, string fieldName = null)
        {
            item.AddAttribute(new Attribute(typeName, name, fieldName));
            return item;
        }

        public static Item WithChildNode(this Item item, string typeName, string name = null, string fieldName = null)
        {
            item.AddChildNode(new Attribute(typeName, name, fieldName));
            return item;
        }

        public static Item WithProperty(this Item item, string typeName, string name, string fieldName = null)
        {
            item.AddProperty(new Property(typeName, name, fieldName));
            return item;
        }

        public static Item IsIKeyedValue(this Item item, string keyAttributeName)
        {
            item.KeyAttributeName = keyAttributeName;
            return item;
        }

        public static Item IsIEquatable(this Item item, params string[] uniqueAttributeNames)
        {
            foreach (var uniqueAttributeName in uniqueAttributeNames)
            {
                item.AddUniqueAttributeName(uniqueAttributeName);
            }

            return item;
        }

        //public static PropertyCollection WithProperty(this PropertyCollection propertyCollection, string typeName, string name, string fieldName = null)
        //{
        //    propertyCollection.AddProperty(new Property(typeName, name, fieldName));
        //    return propertyCollection;
        //}
    }
}
