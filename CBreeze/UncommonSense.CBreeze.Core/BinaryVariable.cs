using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BinaryVariable : Variable
    {
        public BinaryVariable(string name, int? dataLength = null) : this(0, name, dataLength)
        {
        }

        public BinaryVariable(int id, string name, int? dataLength = null)
            : base(id, name)
        {
            DataLength = dataLength.Value == 0 ? 100 : dataLength.GetValueOrDefault(100);
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

        public override string TypeName => $"Binary[{DataLength}]";

        public override VariableType Type
        {
            get
            {
                return VariableType.Binary;
            }
        }
    }
}