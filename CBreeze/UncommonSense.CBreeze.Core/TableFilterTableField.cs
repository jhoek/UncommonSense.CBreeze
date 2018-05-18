using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TableFilterTableField : TableField
    {
        public TableFilterTableField(string name) : this(0, name)
        {
        }

        public TableFilterTableField(int no, string name)
            : base(no, name)
        {
            Properties = new TableFilterTableFieldProperties(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public TableFilterTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.TableFilter;
            }
        }
    }
}