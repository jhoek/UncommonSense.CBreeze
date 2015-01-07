using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Field
    {
        private Visibility visibility = Visibility.Private;
        private string name;
        private string typeName;
        private string initialization;

        public Field(string name, string typeName)
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

        public string Initialization
        {
            get
            {
                return this.initialization;
            }
            set
            {
                this.initialization = value;
            }
        }
    }
}
