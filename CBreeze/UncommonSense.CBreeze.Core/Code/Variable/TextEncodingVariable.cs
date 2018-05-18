using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2016

    public class TextEncodingVariable : Variable,IHasDimensions
    {
        public TextEncodingVariable(string name) : this(0, name)
        {
        }

        public TextEncodingVariable(int id, string name) : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TextEncoding;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }

#endif
}