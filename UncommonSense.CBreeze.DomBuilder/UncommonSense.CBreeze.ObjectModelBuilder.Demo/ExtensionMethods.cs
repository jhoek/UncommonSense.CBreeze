using System;

namespace UncommonSense.CBreeze.ObjectModelBuilder.Demo
{
	public static class ExtensionMethods
	{
        public static Item AddReferenceAttribute(this Item item, string typeName, string name)
        {
            item.Attributes.Add(new ReferenceAttribute(typeName, name));
            return item;
        }

        public static Item AddValueAttribute(this Item item, string typeName, string name)
        {
            item.Attributes.Add(new ValueAttribute(typeName, name));
            return item;
        }

        public static Item AddIdentifierAttribute(this Item item, string typeName, string name)
        {
            item.Attributes.Add(new IdentifierAttribute(typeName, name));
            return item;
        }

        public static Item AddAnotherDerivedItem(this Item item, string name)
        {
            return item.BaseType.AddDerivedItem(name);
        }

        public static Item AddDerivedItem(this Item item, string name)
        {
            item.Abstract = true;
            return item.ObjectModel.Elements.Add(new Item(name, item.Name));
        }
	}
}

