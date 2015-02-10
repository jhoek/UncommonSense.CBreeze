using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class ItemElement
    {
        private string name;
        private string fieldName;
        private Item item;

        public ItemElement(string name)
        {
            this.name = name;
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
