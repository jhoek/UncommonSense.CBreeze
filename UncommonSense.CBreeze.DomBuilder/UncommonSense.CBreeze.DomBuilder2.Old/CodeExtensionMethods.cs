using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public static class CodeExtensionMethods
    {
        public static Project AsProject(this Dom dom)
        {
            var project = new Project(dom.Namespace);

            foreach (var item in dom.ChildNodes.OfType<Item>())
            {
                item.AddToProject(project);
            }

            foreach (var collection in dom.ChildNodes.OfType<Collection>())
            {
                collection.AddToProject(project);
            }

            foreach (var propertyType in dom.ChildNodes.OfType<PropertyType>())
            {
                propertyType.AddToProject(project);
            }

            return project;
        }

        public static Project AsProject(this Item item)
        {
            var project = new Project(item.Dom.Namespace);
            item.AddToProject(project);
            return project;
        }

        public static Project AsProject(this Collection collection)
        {
            var project = new Project(collection.Dom.Namespace);
            collection.AddToProject(project);
            return project;
        }

        public static Project AsProject(this PropertyType propertyType)
        {
            var project = new Project(propertyType.Dom.Namespace);
            propertyType.AddToProject(project);
            return project;
        }

        public static void AddToProject(this Item item, Project project)
        {
            var @class = new Class(item.Name);
            project.Classes.Add(@class);

            // Base types
            if (!string.IsNullOrEmpty(item.BaseTypeName))
                @class.BaseTypesNames.Add(item.BaseTypeName);

            if (item.AutoCollection)
            {
                var collection = new Collection(string.Format("{0}s", item.Name), item.Name);
                collection.AddToProject(project);
            }
        }

        public static void AddToProject(this Collection collection, Project project)
        {
            project.Classes.Add(new Class(collection.Name));
        }

        public static void AddToProject(this PropertyType propertyType, Project project)
        {
            project.Classes.Add(new Class(propertyType.Name));
        }
    }
}
