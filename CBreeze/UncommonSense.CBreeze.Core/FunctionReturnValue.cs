using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class FunctionReturnValue
    {
        internal FunctionReturnValue()
        {
        }

        public string Dimensions
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public FunctionReturnValueType? Type
        {
            get;
            set;
        }

        public int? DataLength
        {
            get;
            set;
        }
    }
}
