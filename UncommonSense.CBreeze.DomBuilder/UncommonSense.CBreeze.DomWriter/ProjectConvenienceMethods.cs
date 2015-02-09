using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public static class ProjectConvenienceMethods
    {
        public static Class AddClass(this Project project, string name)
        {
            var @class = new Class(name);
            project.Classes.Add(@class);
            return @class;
        }

        public static Interface AddInterface(this Project project, string name)
        {
            var @interface = new Interface(name);
            project.Interfaces.Add(@interface);
            return @interface;
        }

        public static Enumeration AddEnumeration(this Project project, string name)
        {
            var enumeration = new Enumeration(name);
            project.Enumerations.Add(enumeration);
            return enumeration;
        }
    }
}
