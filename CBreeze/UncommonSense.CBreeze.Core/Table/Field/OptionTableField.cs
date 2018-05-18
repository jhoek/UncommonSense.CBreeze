using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class OptionTableField : TableField, IHasOptionString
    {
        public OptionTableField(string name) : this(0, name)
        {
        }

        public OptionTableField(int no, string name)
            : base(no, name)
        {
            Properties = new OptionTableFieldProperties(this);
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

        public OptionTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Option;
            }
        }

        public string GetOptionString()
        {
            return Properties.OptionString;
        }
    }
}