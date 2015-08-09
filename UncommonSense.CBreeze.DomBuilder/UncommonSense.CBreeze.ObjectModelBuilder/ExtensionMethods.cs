using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public static partial class ExtensionMethods
    {
        public static Item AddAttribute(this Item item, string typeName, string name = null)
        {
            // FIXME: Now that we have ChildNode and Identifier, should we make Attribute abstract?
            var attribute = new UncommonSense.CBreeze.ObjectModelBuilder.Attribute(typeName, name ?? typeName);
            item.Attributes.Add(attribute);

            return item;
        }

        public static Item AddChildNode(this Item item, string typeName, string name = null)
        {
            var childNode = new ChildNode(typeName, name ?? typeName);
            item.Attributes.Add(childNode);
            return item;
        }

        public static Container AddContainer(this ObjectModel objectModel, string itemTypeName, string name = null)
        {
            var container = new Container(itemTypeName, name ?? string.Format("{0}s", itemTypeName));
            return objectModel.Elements.Add(container);
        }

        public static Enumeration AddEnum(this ObjectModel objectModel, string name, params string[] values)
        {
            var enumeration = new Enumeration(name, values);
            return objectModel.Elements.Add(enumeration);
        }

        public static Item AddIdentifier(this Item item, string typeName, string name = null)
        {
            var identifier = new Identifier(typeName, name ?? typeName);
            item.Attributes.Add(identifier);
            return item;
        }

        public static Item AddItem(this ObjectModel objectModel, string name, string baseTypeName = null, bool @abstract = false, bool createContainer = false, string containerName = null, bool createable = true)
        {
            var item = new Item(name);
            item.BaseTypeName = baseTypeName;
            item.Abstract = @abstract;
            item.Createable = createable;

            if (createContainer)
            {
                objectModel.AddContainer(name, containerName);
            }

            if (@abstract)
            {
                objectModel.AddEnum(string.Format("{0}Type", name));
            }

            if (!string.IsNullOrEmpty(baseTypeName))
            {
                var enumeration = objectModel.Elements.OfType<Enumeration>().First(e => e.Name == string.Format("{0}Type", baseTypeName));
                enumeration.Values.Add(Regex.Replace(name, baseTypeName + "$", ""));
            }

            return objectModel.Elements.Add(item);
        }

        public static PropertyCollection AddProperty(this PropertyCollection propertyCollection, string typeName, string name = null)
        {
            var property = new Property(name ?? typeName, typeName);
            propertyCollection.Add(property);

            return propertyCollection;
        }

        public static PropertyCollection AddPropertyCollection(this ObjectModel objectModel, string name)
        {
            var propertyCollection = new PropertyCollection(name);
            return objectModel.Elements.Add(propertyCollection);
        }

        public static PropertyType AddPropertyType(this ObjectModel objectModel, string name, string innerTypeName)
        {
            var propertyType = new PropertyType(name, innerTypeName);
            return objectModel.Elements.Add(propertyType);
        }

        public static Item Implements(this Item item, string interfaceName)
        {
            item.ImplementedInterfaces.Add(interfaceName);
            return item;
        }
    }
}
