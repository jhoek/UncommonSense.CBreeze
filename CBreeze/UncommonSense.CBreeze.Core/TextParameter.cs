using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextParameter : Parameter
    {
        public TextParameter(bool var, int id, string name, int? dataLength = null)
            : base(var, id, name)
        {
            DataLength = dataLength;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Text;
            }
        }

        public int? DataLength
        {
            get;
            protected set;
        }

    }
}
