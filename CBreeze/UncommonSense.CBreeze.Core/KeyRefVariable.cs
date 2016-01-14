using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
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
