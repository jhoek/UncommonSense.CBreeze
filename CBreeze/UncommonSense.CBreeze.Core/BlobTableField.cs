using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BlobTableField : TableField
    {
        public BlobTableField(string name) : this(0, name)
        {
        }

        public BlobTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BlobTableFieldProperties(this);
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

        public BlobTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.BLOB;
            }
        }
    }
}