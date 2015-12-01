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
    public partial class TextParameter : Parameter
    {
        private int? dataLength;

        public TextParameter(Boolean var, int id, string name, int? dataLength = null) : base(var, id, name)
        {
            this.dataLength = dataLength;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Text;
            }
        }

        public int? DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

    }
}
