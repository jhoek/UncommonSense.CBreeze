using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Project
    {
        private string @namespace;
        private List<string> imports = new List<string>();
        private List<Class> classes = new List<Class>();
        private List<Interface> interfaces = new List<Interface>();
        private List<Enum> enumerations = new List<Enum>();
        
        public Project(string @namespace)
        {
            this.@namespace = @namespace;
        }

        public string Namespace
        {
            get
            {
                return this.@namespace;
            }
        }

        public List<string> Imports
        {
            get
            {
                return this.imports;
            }
        }

        public List<Class> Classes
        {
            get
            {
                return this.classes;
            }
        }

        public List<Interface> Interfaces
        {
            get
            {
                return this.interfaces;
            }
        }

        public List<Enum> Enumerations
        {
            get
            {
                return this.enumerations;
            }
        }
    }
}
