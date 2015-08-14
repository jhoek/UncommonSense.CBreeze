using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class OcxVariable : Variable
    {
        private String dimensions;
        private String subType;

        internal OcxVariable(Int32 id, String name, String subType) : base(id, name)
        {
            this.subType = subType;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Ocx;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

    }
}
