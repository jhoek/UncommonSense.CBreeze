using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TextConstant : Variable
    {
        public TextConstant(string name) : this(0, name)
        {
        }

        public TextConstant(int id, string name)
            : base(id, name)
        {
            Values = new MultiLanguageValue();
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TextConst;
            }
        }

        public MultiLanguageValue Values
        {
            get;
            protected set;
        }
    }
}