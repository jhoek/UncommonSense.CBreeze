using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016

    public class FilterPageBuilderVariable : Variable
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