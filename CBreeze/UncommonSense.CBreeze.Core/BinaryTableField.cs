using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class BinaryTableField : TableField
    {
        public BinaryTableField(int no, string name, int dataLength = 4)
            : base(no, name)
        {
            DataLength = dataLength;
            Properties = new BinaryTableFieldProperties(this);
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Binary;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", base.ToString(), DataLength);
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public BinaryTableFieldProperties Properties
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

        public override IEnumerable<INode> ChildNodes 
        {
            get
            {
                yield return Properties;
            }
        }
    }
}
