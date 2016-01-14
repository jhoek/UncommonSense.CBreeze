using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class CodeunitParameter : Parameter
    {
        public CodeunitParameter(bool var, int id, string name, int subType)
            : base(var, id, name)
        {
            SubType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Codeunit;
            }
        }

        public int SubType
        {
            get;
            protected set;
        }
    }
}
