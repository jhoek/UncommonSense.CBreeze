using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DateVariable : Variable
    {
        public DateVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Date;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
