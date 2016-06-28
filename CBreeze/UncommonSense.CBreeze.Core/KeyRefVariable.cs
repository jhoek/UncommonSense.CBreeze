using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class KeyRefVariable : Variable
    {
        public KeyRefVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.KeyRef;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
