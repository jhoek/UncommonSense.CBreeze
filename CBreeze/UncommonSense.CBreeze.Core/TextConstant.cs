using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextConstant : Variable
    {
        public TextConstant(int id, string name)
            : base(id, name)
        {
            Values = new MultiLanguageValue();
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TextConstant;
            }
        }

        public MultiLanguageValue Values
        {
            get;
            protected set;
        }
    }
}
