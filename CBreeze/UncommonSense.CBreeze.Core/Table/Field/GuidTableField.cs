using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class GuidTableField : TableField
    {
        public GuidTableField(string name) : this(0, name)
        {
        }

        public GuidTableField(int no, string name)
            : base(no, name)
        {
            Properties = new GuidTableFieldProperties(this);
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

        public GuidTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Guid;
            }
        }
    }
}