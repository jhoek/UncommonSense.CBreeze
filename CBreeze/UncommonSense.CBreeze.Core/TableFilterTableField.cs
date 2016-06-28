using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class TableFilterTableField : TableField
    {
        public TableFilterTableField(int no, string name)
            : base(no, name)
        {
            Properties = new TableFilterTableFieldProperties();
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
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
