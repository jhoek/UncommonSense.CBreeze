using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2016

    public class FilterPageBuilderVariable : Variable,IHasDimensions
    {
        public FilterPageBuilderVariable(string name) : this(0, name)
        {
        }

        public FilterPageBuilderVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.FilterPageBuilder;
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