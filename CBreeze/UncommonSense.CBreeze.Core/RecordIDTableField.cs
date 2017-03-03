using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class RecordIDTableField : TableField
    {
        public RecordIDTableField(string name) : this(0, name)
        {
        }

        public RecordIDTableField(int no, string name)
            : base(no, name)
        {
            Properties = new RecordIDTableFieldProperties(this);
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

        public RecordIDTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.RecordID;
            }
        }
    }
}