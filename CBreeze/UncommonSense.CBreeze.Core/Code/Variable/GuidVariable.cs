using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class GuidVariable : Variable,IHasDimensions
    {
        public GuidVariable(string name) : this(0, name)
        {
        }

        public GuidVariable(int id, string name)
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
                return VariableType.Guid;
            }
        }

        public override string TypeName => "GUID";
    }
}