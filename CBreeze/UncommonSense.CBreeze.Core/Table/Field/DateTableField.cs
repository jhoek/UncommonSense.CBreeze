using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class DateTableField : TableField
    {
        public DateTableField(string name) : this(0, name)
        {
        }

        public DateTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DateTableFieldProperties(this);
        }

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public DateTableFieldProperties Properties { get; protected set; }
        public override TableFieldType Type => TableFieldType.Date;
    }
}