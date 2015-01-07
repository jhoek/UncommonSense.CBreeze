using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Interface 
    {
        private string name;
        private Visibility visibility = Visibility.Public;
        private readonly List<string> baseTypeNames = new List<string>();
        private readonly List<InterfaceMethod> methods = new List<InterfaceMethod>();
        private readonly List<InterfaceProperty> properties = new List<InterfaceProperty>();

        public Interface(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Visibility Visibility
        {
            get
            {
                return this.visibility;
            }
            set
            {
                this.visibility = value;
            }
        }

        public List<string> BaseTypesNames
        {
            get
            {
                return this.baseTypeNames;
            }
        }

        public List<InterfaceMethod> Methods
        {
            get
            {
                return this.methods;
            }
        }

        public List<InterfaceProperty> Properties
        {
            get
            {
                return this.properties;
            }
        }
    }
}
