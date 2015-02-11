using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomBuilder
{
    public static class AddToProjectExtensionMethods
    {
        public static void AddToProject(this Item item, Project project)
        {
            var @class = project.AddClass(item.Name);

            if (!string.IsNullOrEmpty(item.BaseItemName))
            {
                @class.BaseTypesNames.Add(item.BaseItemName);
            }

            foreach (var attribute in item.Attributes)
            {
                var field = @class.AddField(attribute.FieldName, attribute.TypeName);
                field.Initialization = string.Format("new {0}()", attribute.TypeName);

                var property = @class.AddProperty(attribute.Name, attribute.TypeName);

                if (property.Type is ReferencePropertyType)
            }
        }

        public static void AddToProject(this Container container, Project project)
        {
            var @class = new Class(container.Name);
            project.Classes.Add(@class);
        }

        public static void AddToProject(this Enumeration enumeration, Project project)
        {
            var @enum = new Enum(project.AddEnumeration(enumeration.Name);
        }
    }
}
