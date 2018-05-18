using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
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

        public override Property.Properties AllProperties
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