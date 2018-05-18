using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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