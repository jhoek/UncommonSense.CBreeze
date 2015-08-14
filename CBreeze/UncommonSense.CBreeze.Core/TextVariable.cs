using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextVariable : Variable
    {
        private Int32? dataLength;
        private String dimensions;
        private Boolean? includeInDataset;

        internal TextVariable(Int32 id, String name, Int32? dataLength = null) : base(id, name)
        {
            this.dataLength = dataLength;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Text;
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

        public Boolean? IncludeInDataset
        {
            get
            {
                return this.includeInDataset;
            }
            set
            {
                this.includeInDataset = value;
            }
        }

    }
}
