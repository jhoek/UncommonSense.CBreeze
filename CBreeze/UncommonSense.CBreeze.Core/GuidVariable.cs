using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class GuidVariable : Variable
    {
        public GuidVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Guid;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
