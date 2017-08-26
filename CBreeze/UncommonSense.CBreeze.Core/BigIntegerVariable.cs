using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BigIntegerVariable : Variable
    {
        public BigIntegerVariable(string name) : this(0, name)
        {
        }

        public BigIntegerVariable(int id, string name)
            : base(id, name)
        {
        }

        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.BigInteger;
    }
}