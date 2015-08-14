using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class CalcFormula
    {
        private String fieldName;
        private CalcFormulaMethod? method;
        private Boolean reverseSign;
        private CalcFormulaTableFilter tableFilter = new CalcFormulaTableFilter();
        private String tableName;

        internal CalcFormula()
        {
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }

        public CalcFormulaMethod? Method
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }

        public Boolean ReverseSign
        {
            get
            {
                return this.reverseSign;
            }
            set
            {
                this.reverseSign = value;
            }
        }

        public CalcFormulaTableFilter TableFilter
        {
            get
            {
                return this.tableFilter;
            }
        }

        public String TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }

    }
}
