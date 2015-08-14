using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class OptionParameter : Parameter
    {
        private String dimensions;
        private String optionString;

        internal OptionParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Option;
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
