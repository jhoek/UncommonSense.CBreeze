using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class DateTableField : TableField
    {
        public DateTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DateTableFieldProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override TableFieldType Type => TableFieldType.Date;
        public DateTableFieldProperties Properties { get; protected set; }
        public override Properties AllProperties => Properties;
    }
}
