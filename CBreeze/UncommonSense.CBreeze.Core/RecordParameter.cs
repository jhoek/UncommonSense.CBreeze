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
    public partial class RecordParameter : Parameter
    {
        private RecordSecurityFiltering? securityFiltering;
        private int subType;
        private Boolean? temporary;

        public RecordParameter(Boolean var, int id, string name, int subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Record;
            }
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

        public int SubType
        {
            get
            {
                return this.subType;
            }
        }

        public Boolean? Temporary
        {
            get
            {
                return this.temporary;
            }
            set
            {
                this.temporary = value;
            }
        }

    }
}
