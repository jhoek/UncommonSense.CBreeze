using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DateFormulaTableField : TableField
    {
        private DateFormulaTableFieldProperties properties = new DateFormulaTableFieldProperties();

        internal DateFormulaTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
