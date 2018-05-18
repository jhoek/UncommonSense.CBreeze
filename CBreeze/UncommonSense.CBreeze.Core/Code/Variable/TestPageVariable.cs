using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TestPageVariable : Variable,IHasDimensions
    {
        public TestPageVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public TestPageVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"TestPage {SubType}";

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
                return VariableType.TestPage;
            }
        }
    }
}