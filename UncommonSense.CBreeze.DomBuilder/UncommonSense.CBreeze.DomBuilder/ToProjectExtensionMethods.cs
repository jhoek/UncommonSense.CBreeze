using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomBuilder
{
    public static class ToProjectExtensionMethods
    {
        public static Project ToProject(this ObjectModel objectModel)
        {
            var project = new Project(objectModel.Namespace);

            foreach (var item in objectModel.Elements.OfType<Item>())
            {
                item.AddToProject(project);
            }

            foreach (var enumeration in objectModel.Elements.OfType<Enumeration>())
            {
                enumeration.AddToProject(project);
            }

            return project;
        }
    }
}
