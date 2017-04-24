using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class BooleanVariable : Variable
    {
        public BooleanVariable(string name) : this(0, name)
        {
        }

        public BooleanVariable(int id, string name)
            : base(id, name)
        {
        }

        public string Dimensions
        {
            get;
            set;
        }

        public bool? IncludeInDataset
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Boolean;
            }
        }
    }
}