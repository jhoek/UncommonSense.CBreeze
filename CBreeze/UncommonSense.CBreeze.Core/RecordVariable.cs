using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class RecordVariable : Variable
    {
        public RecordVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Record;
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

        public int SubType
        {
            get;
            protected set;
        }

        public bool? Temporary
        {
            get;
            set;
        }
    }
}
