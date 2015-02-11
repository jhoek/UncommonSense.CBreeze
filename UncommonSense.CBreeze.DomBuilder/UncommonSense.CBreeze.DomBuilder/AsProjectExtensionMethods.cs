using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomBuilder
{
    public static class AsProjectExtensionMethods
    {
        public static Project AsProject(this ObjectModel objectModel)
        {
            var project = new Project(objectModel.Namespace);

            foreach (var item in objectModel.Elements.OfType<Item>())
            {
                item.AddToProject(project);
            }

            foreach (var container in objectModel.Elements.OfType<Container>())
            {
                container.AddToProject(project);
            }

            foreach (var enumeration in objectModel.Elements.OfType<Enumeration>())
            {
                enumeration.AddToProject(project);
            }

            return project;
        }

        public static Project AsProject(this Item item)
        {
            var project = new Project((item.ParentNode as ObjectModel).Namespace);
            item.AddToProject(project);
            return project;
        }

        public static Project AsProject(this Container container)
        {
            var project = new Project((container.ParentNode as ObjectModel).Namespace);
            // FIXME: container.AddToProject(project);
            return project;
        }
    }
}
