using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class CodeunitVariable : Variable,IHasDimensions
    {
        public CodeunitVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public override string TypeName => $"Codeunit {SubType}";

        public CodeunitVariable(int id, string name, int subType)
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
                return VariableType.Codeunit;
            }
        }
    }
}