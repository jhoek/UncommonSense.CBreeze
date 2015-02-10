using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Property : ItemElement
    {
        private string typeName;
        private string fieldName;

        public Property(string name, string typeName)
            : base(name)
        {
            this.typeName = typeName;
        }

        public static string GetFieldName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            return name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
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
    }
}
