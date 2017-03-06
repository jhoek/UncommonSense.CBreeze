using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016

    public class TextEncodingParameter : Parameter
    {
        public TextEncodingParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.TextEncoding;
    }

#endif
}