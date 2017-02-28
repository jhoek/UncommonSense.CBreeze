using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class RecordIDTableField : TableField
    {
        public RecordIDTableField(int no, string name)
            : base(no, name)
        {
            Properties = new RecordIDTableFieldProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.RecordID;
            }
        }

        public RecordIDTableFieldProperties Properties
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
