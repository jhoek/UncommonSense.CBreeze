using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class CalcFormulaProperty : Property
    {
        private CalcFormula value = new CalcFormula();

        internal CalcFormulaProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Method.HasValue;
            }
        }

        public CalcFormula Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
