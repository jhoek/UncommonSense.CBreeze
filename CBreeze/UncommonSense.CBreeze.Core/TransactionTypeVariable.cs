using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TransactionTypeVariable : Variable
    {
        public TransactionTypeVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TransactionType;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
