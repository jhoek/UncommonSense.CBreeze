using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class OcxParameter : Parameter
    {
        public OcxParameter(bool var, int id, string name, string subType)
            : base(var, id, name)
        {
            SubType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Ocx;
            }
        }

        public string SubType
        {
            get;
            protected set;
        }
    }
}
