using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class AutomationVariable : Variable
    {
        public AutomationVariable(string name, string subType) : this(0, name, subType)
        {
        }

        public AutomationVariable(int id, string name, string subType)
            : base(id, name)
        {
            SubType = subType;
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

        public override VariableType Type
        {
            get
            {
                return VariableType.Automation;
            }
        }

        public bool? WithEvents
        {
            get;
            set;
        }
    }
}