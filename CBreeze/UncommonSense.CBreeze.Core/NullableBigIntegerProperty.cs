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
    public class NullableBigIntegerProperty : Property
    {
        private System.Int64? value = null;

        internal NullableBigIntegerProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Int64? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

}