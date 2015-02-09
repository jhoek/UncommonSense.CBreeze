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
        }

        public static void AddToProject(this Enumeration enumeration, Project project)
        {
            var @enum = project.AddEnumeration(enumeration.Name);
        }
    }
}
