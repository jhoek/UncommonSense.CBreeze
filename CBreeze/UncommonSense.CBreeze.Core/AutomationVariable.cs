using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class AutomationVariable : Variable
    {
        public AutomationVariable(int id, string name, string subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Automation;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }

        public string SubType
        {
            get;
            protected set;
        }

        public bool? WithEvents
        {
            get;
            set;
        }
    }
}
