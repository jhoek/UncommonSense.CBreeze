using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableKey
    {
        private Boolean? enabled;
        private FieldList fields = new FieldList();
        private TableKeyProperties properties = new TableKeyProperties();

        internal TableKey()
        {
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

        public FieldList Fields
        {
            get
            {
                return this.fields;
            }
        }

        public TableKeyProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
