using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableFilterTableField : TableField
    {
        private TableFilterTableFieldProperties properties = new TableFilterTableFieldProperties();

        internal TableFilterTableField(Int32 no, String name) : base(no, name)
        {
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.TableFilter;
            }
        }

        public TableFilterTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
