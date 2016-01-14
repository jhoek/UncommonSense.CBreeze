using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class CharVariable : Variable
    {
        public CharVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Char;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
