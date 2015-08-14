using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public abstract partial class TableField
    {
        private Int32 no;
        private String name;
        private Boolean? enabled;

        internal TableField(Int32 no, String name)
        {
            this.name = name;
            this.no = no;
        }

        public abstract TableFieldType Type
        {
            get;
        }

        public Int32 No
        {
            get
            {
                return this.no;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public Boolean? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

    }
}
