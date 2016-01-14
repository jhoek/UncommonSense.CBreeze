using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class BinaryVariable : Variable
    {
        public BinaryVariable(int id, string name, int dataLength = 100)
            : base(id, name)
        {
            DataLength = dataLength;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Binary;
            }
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public string Dimensions
        {
            get;
            set;
        }

    }
}
