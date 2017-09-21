using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class CodeVariable : Variable
    {
        public CodeVariable(string name, int? dataLength = null) : this(0, name, dataLength)
        {
        }

        public override string TypeName => $"Code[{DataLength}]";

        public CodeVariable(int id, string name, int? dataLength = null)
            : base(id, name)
        {
            DataLength = dataLength.Value == 0 ? 10 : dataLength.GetValueOrDefault(10);
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

        public bool? IncludeInDataset
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Code;
            }
        }
    }
}