using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class InStreamVariable : Variable
    {
        public InStreamVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.InStream;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
