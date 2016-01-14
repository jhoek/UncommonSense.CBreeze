using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class FieldRefVariable : Variable
    {
        public FieldRefVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.FieldRef;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
