using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class BooleanTableField : TableField
    {
        public BooleanTableField(string name) : base(0, name)
        {
        }

        public BooleanTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BooleanTableFieldProperties(this);
        }

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public BooleanTableFieldProperties Properties { get; protected set; }

        public override TableFieldType Type => TableFieldType.Boolean;
    }
}