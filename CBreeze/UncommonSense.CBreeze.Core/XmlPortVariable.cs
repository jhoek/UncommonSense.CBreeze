using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlPortVariable : Variable
    {
        public XmlPortVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.XmlPort;
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
