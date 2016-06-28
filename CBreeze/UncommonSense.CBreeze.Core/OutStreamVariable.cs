using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class OutStreamVariable : Variable
    {
        public OutStreamVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.OutStream;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
