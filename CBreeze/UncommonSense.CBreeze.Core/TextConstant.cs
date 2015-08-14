using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextConstant : Variable
    {
        private MultiLanguageValue values = new MultiLanguageValue();

        internal TextConstant(Int32 id, String name) : base(id, name)
        {
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
            get
            {
                return this.values;
            }
        }

    }
}
