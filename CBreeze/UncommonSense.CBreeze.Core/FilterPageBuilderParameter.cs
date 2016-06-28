using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
        public class FilterPageBuilderParameter : Parameter
    {
        public FilterPageBuilderParameter(bool var, int id, string name)
            : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.FilterPageBuilder;
            }
        }
    }
#endif
}
