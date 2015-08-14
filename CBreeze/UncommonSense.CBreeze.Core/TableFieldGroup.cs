using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableFieldGroup
    {
        private Int32 id;
        private String name;
        private FieldList fields = new FieldList();
        private TableFieldGroupProperties properties = new TableFieldGroupProperties();

        internal TableFieldGroup(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public FieldList Fields
        {
            get
            {
                return this.fields;
            }
        }

        public TableFieldGroupProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
