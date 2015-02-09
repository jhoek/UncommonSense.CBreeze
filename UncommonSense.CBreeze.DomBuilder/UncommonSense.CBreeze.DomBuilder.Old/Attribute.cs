using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Attribute
    {
        private Item item;
        private string typeName; 
        private string name;
        private string fieldName;

        public Attribute(string typeName, string name, string fieldName)
        {
            this.typeName = typeName;
            this.name = name;
            this.fieldName = fieldName;
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

        public string TypeName
        {
            get
            {
                return this.typeName;
            }
        }

        public string Name
        {
            get
            {
                return this.name ?? this.typeName;
            }
        }

        public string FieldName
        {
            get
            {
                return this.fieldName ?? Name.Substring(0, 1).ToLowerInvariant() + Name.Substring(1);
            }
        }
    }
}
