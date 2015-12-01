// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextVariable : Variable
    {
        private int? dataLength;
        private string dimensions;
        private Boolean? includeInDataset;

        public TextVariable(int id, string name, int? dataLength = null) : base(id, name)
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

        public int? DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public string Dimensions
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
