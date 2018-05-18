using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class TimeTableField : TableField
    {
        public TimeTableField(string name) : this(0, name)
        {
        }

        public TimeTableField(int no, string name)
            : base(no, name)
        {
            Properties = new TimeTableFieldProperties(this);
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

        public TimeTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Time;
            }
        }
    }
}