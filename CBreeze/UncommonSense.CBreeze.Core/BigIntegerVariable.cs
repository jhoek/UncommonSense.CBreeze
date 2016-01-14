using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class BigIntegerVariable : Variable
    {
        public BigIntegerVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.BigInteger;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

    }
}
