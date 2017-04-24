using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class PageVariable : Variable
    {
        public PageVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public PageVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public string Dimensions
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Page;
            }
        }
    }
}