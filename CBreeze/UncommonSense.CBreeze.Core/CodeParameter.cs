using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class CodeParameter : Parameter
    {
        public CodeParameter(bool var, int id, string name, int? dataLength = null)
            : base(var, id, name)
        {
            DataLength = dataLength;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Code;
            }
        }

        public int? DataLength
        {
            get;
            protected set;
        }
    }
}
