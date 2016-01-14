using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class RecordIDVariable : Variable
    {
        public RecordIDVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.RecordID;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
