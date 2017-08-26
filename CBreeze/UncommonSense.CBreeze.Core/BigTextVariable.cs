using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BigTextVariable : Variable
    {
        public BigTextVariable(string name)
            : this(0, name)
        {
        }

        public BigTextVariable(int id, string name)
            : base(id, name)
        {
        }

        public string Dimensions { get; set; }

        public override VariableType Type => VariableType.BigText;
    }
}