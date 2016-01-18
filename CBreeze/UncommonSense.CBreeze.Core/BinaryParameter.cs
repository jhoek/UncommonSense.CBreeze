using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class BinaryParameter : Parameter
    {
        public BinaryParameter(bool var, int id, string name, int dataLength = 100)
            : base(var, id, name)
        {
            DataLength = dataLength;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Binary;
            }
        }

        public int DataLength
        {
            get;
            protected set;
        }

    }
}
