using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Class 
    {
        private string name;
        private bool @abstract = false;
        private bool @sealed = false;
        private Visibility visibility = Visibility.Public;
        private readonly List<string> baseTypeNames = new List<string>();
        private readonly Dictionary<string, string> constraints = new Dictionary<string, string>();
        private readonly List<Field> fields = new List<Field>();
        private readonly List<Constructor> constructors = new List<Constructor>();
        private readonly List<ClassMethod> methods = new List<ClassMethod>();
        private readonly List<ClassProperty> properties = new List<ClassProperty>();

        public Class(string name)
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

        public bool Abstract
        {
            get
            {
                return this.@abstract;
            }
            set
            {
                this.@abstract = value;
            }
        }

        public bool Sealed
        {
            get
            {
                return this.@sealed;
            }
            set
            {
                this.@sealed = value;
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

        public Dictionary<string, string> Constraints
        {
            get
            {
                return this.constraints;
            }
        }

        public List<Field> Fields
        {
            get
            {
                return this.fields;
            }
        }

        public List<Constructor> Constructors
        {
            get
            {
                return this.constructors;
            }
        }

        public List<ClassMethod> Methods
        {
            get
            {
                return this.methods;
            }
        }

        public List<ClassProperty> Properties
        {
            get
            {
                return this.properties;
            }
        }
    }
}
