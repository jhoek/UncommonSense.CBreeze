using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class DateFormulaTableField : TableField
    {
        public DateFormulaTableField(string name) : this(0, name)
        {
        }

        public DateFormulaTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DateFormulaTableFieldProperties(this);
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

        public DateFormulaTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.DateFormula;
            }
        }
    }
}