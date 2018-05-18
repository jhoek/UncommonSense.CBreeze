using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016

    public class TableConnectionTypeVariable : Variable,IHasDimensions
    {
        public TableConnectionTypeVariable(string name) : this(0, name)
        {
        }

        public TableConnectionTypeVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.TableConnectionType;
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