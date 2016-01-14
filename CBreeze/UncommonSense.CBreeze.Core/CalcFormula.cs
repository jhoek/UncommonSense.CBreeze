using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class CalcFormula
    {
        // Ctor made public to allow CalcFormulaProperty to new up an instance
        public CalcFormula()
        {
            TableFilter = new CalcFormulaTableFilter();
        }

        public void Set(CalcFormulaMethod method, string tableName, string fieldName, bool reverseSign = false, params CalcFormulaTableFilterLine[] tableFilter)
        {
            Method = method;
            TableName = tableName;
            FieldName = fieldName;
            ReverseSign = reverseSign;
            TableFilter.AddRange(tableFilter);
        }

        public string FieldName
        {
            get;
            set;
        }

        public CalcFormulaMethod? Method
        {
            get;
            set;
        }

        public bool ReverseSign
        {
            get;
            set;
        }

        public CalcFormulaTableFilter TableFilter
        {
            get;
            protected set;
        }

        public string TableName
        {
            get;
            set;
        }

    }
}
