using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Code.Variable
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