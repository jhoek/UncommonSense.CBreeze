using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class BigTextVariable : Variable
    {
        public BigTextVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.BigText;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

    }
}
