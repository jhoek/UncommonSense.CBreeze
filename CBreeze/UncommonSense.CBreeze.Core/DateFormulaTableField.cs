using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DateFormulaTableField : TableField
    {
        public DateFormulaTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DateFormulaTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.DateFormula;
            }
        }

        public DateFormulaTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
