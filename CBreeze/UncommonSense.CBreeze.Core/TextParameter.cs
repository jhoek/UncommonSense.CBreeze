using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class TextParameter : Parameter
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
