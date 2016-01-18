using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class AutomationParameter : Parameter
    {
        public AutomationParameter(bool var, int id, string name, string subType)
            : base(var, id, name)
        {
            SubType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Automation;
            }
        }

        public string SubType
        {
            get;
            protected set;
        }

    }
}
