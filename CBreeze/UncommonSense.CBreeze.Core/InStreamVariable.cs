using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class InStreamVariable : Variable,IHasDimensions
    {
        public InStreamVariable(string name) : this(0, name)
        {
        }

        public InStreamVariable(int id, string name)
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
                return VariableType.InStream;
            }
        }
    }
}