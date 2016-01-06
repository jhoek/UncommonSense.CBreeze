using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TextEncodingParameter : Parameter
    {
        public TextEncodingParameter(bool var, int id, string name)
            : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.TextEncoding;
            }
        }
    }
}
