using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DecimalVariable : Variable
    {
        public DecimalVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Decimal;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
