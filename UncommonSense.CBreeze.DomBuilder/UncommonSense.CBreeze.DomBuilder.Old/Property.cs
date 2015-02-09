using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Property
    {
        private string typeName;
        private string name;
        private string fieldName;
        private Item item;

        public Property(string typeName, string name, string fieldName)
        {
            this.typeName = typeName;
            this.name = name;
            this.fieldName = fieldName;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string FieldName
        {
            get
            {
                return this.fieldName ?? Name.Substring(0, 1).ToLowerInvariant() + Name.Substring(1);
            }
        }

        public string TypeName
        {
            get
            {
                return this.typeName;
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
