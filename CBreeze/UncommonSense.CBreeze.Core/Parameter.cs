using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public abstract partial class Parameter
    {
        private Boolean var;
        private Int32 id;
        private String name;

        internal Parameter(Boolean var, Int32 id, String name)
        {
            this.id = id;
            this.name = name;
            this.var = var;
        }

        public abstract ParameterType Type
        {
            get;
        }

        public Boolean Var
        {
            get
            {
                return this.var;
            }
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

    }
}
