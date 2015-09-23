using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class CalcFormulaExtensionMethods
    {
        public static void Set(this CalcFormula calcFormula, CalcFormulaMethod method, string tableName, string fieldName, bool reverseSign = false, params CalcFormulaTableFilterLine[] tableFilter)
        {
            calcFormula.Method = method;
            calcFormula.TableName = tableName;
            calcFormula.FieldName = fieldName;
            calcFormula.ReverseSign = reverseSign;
            calcFormula.TableFilter.AddRange(tableFilter);
        }
    }
}
