using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class RecordRefVariable : Variable
    {
        public RecordRefVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.RecordRef;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get;
            set;
        }
    }
}
