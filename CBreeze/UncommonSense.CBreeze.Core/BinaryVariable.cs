using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BinaryVariable : Variable
    {
        public BinaryVariable(string name, int dataLength = 100) : this(0, name, dataLength)
        {
        }

        public BinaryVariable(int id, string name, int dataLength = 100)
            : base(id, name)
        {
            DataLength = dataLength;
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

        public override VariableType Type
        {
            get
            {
                return VariableType.Binary;
            }
        }
    }
}