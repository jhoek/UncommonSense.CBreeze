using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DateTimeVariable : Variable
    {
        public DateTimeVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.DateTime;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
