using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BinaryParameter : Parameter
    {
        public BinaryParameter(string name, bool var = false, int id = 0, int dataLength = 100) : base(name, var, id)
        {
            DataLength = dataLength;
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Binary;
        public override string TypeName => $"Binary[{DataLength}]";
    }
}