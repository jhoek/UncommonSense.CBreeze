using System.Linq;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class CalcFormula
    {
        // Ctor made public to allow CalcFormulaProperty to new up an instance
        public CalcFormula()
        {
            TableFilter = new CalcFormulaTableFilter();
        }

        public void Set(CalcFormula calcFormula)
        {
            Method = calcFormula?.Method;
            TableName = calcFormula?.TableName;
            FieldName = calcFormula?.FieldName;
            ReverseSign = calcFormula?.ReverseSign ?? false;

            TableFilter.Clear();
            TableFilter.AddRange(calcFormula?.TableFilter ?? Enumerable.Empty<CalcFormulaTableFilterLine>());
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
