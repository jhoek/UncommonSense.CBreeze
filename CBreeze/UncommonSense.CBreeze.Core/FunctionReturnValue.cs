using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class FunctionReturnValue
    {
        private String dimensions;
        private String name;
        private FunctionReturnValueType? type;
        private Int32? dataLength;

        internal FunctionReturnValue()
        {
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

        public FunctionReturnValueType? Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
            }
            set
            {
                this.dataLength = value;
            }
        }

    }
}
