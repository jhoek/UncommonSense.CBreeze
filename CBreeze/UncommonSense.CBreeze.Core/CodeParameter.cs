using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class CodeParameter : Parameter
    {
        private Int32? dataLength;
        private String dimensions;

        internal CodeParameter(Boolean var, Int32 id, String name, Int32? dataLength = null) : base(var, id, name)
        {
            this.dataLength = dataLength;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Code;
            }
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
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

    }
}
