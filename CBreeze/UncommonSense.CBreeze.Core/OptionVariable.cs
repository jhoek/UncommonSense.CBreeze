using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class OptionVariable : Variable
    {
        private String dimensions;
        private String optionString;

        internal OptionVariable(Int32 id, String name) : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Option;
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

        public String OptionString
        {
            get
            {
                return this.optionString;
            }
            set
            {
                this.optionString = value;
            }
        }

    }
}
