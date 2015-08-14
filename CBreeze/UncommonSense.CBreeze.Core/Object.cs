using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public abstract partial class Object
    {
        private Int32 id;
        private String name;
        private ObjectProperties objectProperties = new ObjectProperties();

        internal Object(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public abstract ObjectType Type
        {
            get;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public ObjectProperties ObjectProperties
        {
            get
            {
                return this.objectProperties;
            }
        }

    }
}
