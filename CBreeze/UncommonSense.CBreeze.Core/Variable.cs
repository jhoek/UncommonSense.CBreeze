using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public abstract partial class Variable
    {
        private Int32 id;
        private String name;

        internal Variable(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public abstract VariableType Type
        {
            get;
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
