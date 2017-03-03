using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class DurationTableField : TableField
    {
        public DurationTableField(string name) : this(0, name)
        {
        }

        public DurationTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DurationTableFieldProperties(this);
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

        public DurationTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type => TableFieldType.Duration;
    }
}