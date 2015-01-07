using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public abstract class Property
    {
        private Visibility visibility = Visibility.Public;
        private string name;
        private string typeName;
        private bool hasGetter;
        private bool hasSetter;

        public Property(string name, string typeName)
        {
            this.name = name;
            this.typeName = typeName;
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

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string TypeName
        {
            get
            {
                return this.typeName;
            }
        }

        public bool HasGetter
        {
            get
            {
                return hasGetter;
            }
            set
            {
                hasGetter = value;
            }
        }

        public bool HasSetter
        {
            get
            {
                return hasSetter;
            }
            set
            {
                this.hasSetter = true;
            }
        }
    }
}
