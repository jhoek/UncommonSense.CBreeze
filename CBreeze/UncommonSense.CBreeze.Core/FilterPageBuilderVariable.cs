using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
    [Serializable]
    public class FilterPageBuilderVariable : Variable
    {
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
