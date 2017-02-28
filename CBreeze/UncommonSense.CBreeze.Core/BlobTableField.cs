using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class BlobTableField : TableField
    {
        public BlobTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BlobTableFieldProperties(this);
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
                return TableFieldType.BLOB;
            }
        }

        public BlobTableFieldProperties Properties
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
