using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class BooleanParameter : Parameter
    {
        public BooleanParameter(bool var, int id, string name) : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Boolean;
            }
        }

    }
}
