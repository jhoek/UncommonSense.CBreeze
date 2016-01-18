using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TestRequestPageParameter : Parameter
    {
        public TestRequestPageParameter(bool var, int id, string name, int subType)
            : base(var, id, name)
        {
            SubType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.TestRequestPage;
            }
        }

        public int SubType
        {
            get;
            protected set;
        }
    }
}
