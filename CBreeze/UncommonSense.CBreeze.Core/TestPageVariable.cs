using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TestPageVariable : Variable
    {
        public TestPageVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TestPage;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }
    }
}
