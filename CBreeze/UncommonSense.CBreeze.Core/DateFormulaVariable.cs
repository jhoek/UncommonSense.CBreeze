using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class DateFormulaVariable : Variable,IHasDimensions
    {
        public DateFormulaVariable(string name) : this(0, name)
        {
        }

        public DateFormulaVariable(int id, string name)
            : base(id, name)
        {
        }

        public string Dimensions
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.DateFormula;
            }
        }
    }
}