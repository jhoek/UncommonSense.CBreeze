using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DurationVariable : Variable
    {
        public DurationVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Duration;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
