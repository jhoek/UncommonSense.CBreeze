using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ExecutionModeVariable : Variable
    {
        public ExecutionModeVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get 
            {
                return VariableType.ExecutionMode;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
