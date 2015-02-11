using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class Attribute
    {
        private string name;
        private string typeName;
        private string fieldName;
        private Item item;

        public Attribute(string name)
            : this(name, name)
        {
        }

        public Attribute(string name, string typeName)
        {
            this.name = name;
            this.typeName = typeName;
        }

        public static string GetFieldName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            return name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
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

        public string FieldName
        {
            get
            {
                return this.fieldName ?? GetFieldName(Name);
            }
            set
            {
                this.fieldName = value;
            }
        }

        public Item Item
        {
            get
            {
                return this.item;
            }
            internal set
            {
                this.item = value;
            }
        }
    }
}
