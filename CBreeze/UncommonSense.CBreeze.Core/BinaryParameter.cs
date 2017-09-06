using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BinaryParameter : Parameter
    {
        public BinaryParameter(string name, bool var = false, int id = 0, int? dataLength = null) : base(name, var, id)
        {
            DataLength = dataLength.Value == 0 ? 100 : dataLength.GetValueOrDefault(100);
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