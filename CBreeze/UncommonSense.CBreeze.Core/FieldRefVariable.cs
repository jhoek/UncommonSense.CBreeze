using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class FieldRefVariable : Variable,IHasDimensions
    {
        public FieldRefVariable(string name) : this(0, name)
        {
        }

        public FieldRefVariable(int id, string name)
            : base(id, name)
        {
        }

        public string Dimensions
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.FieldRef;
            }
        }
    }
}