using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class OcxVariable : Variable
    {
        public OcxVariable(int id, string name, string subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Ocx;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

        public string SubType
        {
            get;
            protected set;
        }
    }
}
