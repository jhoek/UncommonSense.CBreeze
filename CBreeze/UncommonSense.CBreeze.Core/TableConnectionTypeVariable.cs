using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
        public class TableConnectionTypeVariable : Variable
    {
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
