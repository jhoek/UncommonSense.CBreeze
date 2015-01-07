using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class CalcFormulaTableFilterTypeExtensionMethods
    {
        public static string AsString(this CalcFormulaTableFilterType type)
        {
            switch (type)
            {
                case CalcFormulaTableFilterType.Const:
                    return "CONST";
                case CalcFormulaTableFilterType.Field:
                    return "FIELD";
                case CalcFormulaTableFilterType.Filter:
                    return "FILTER";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
