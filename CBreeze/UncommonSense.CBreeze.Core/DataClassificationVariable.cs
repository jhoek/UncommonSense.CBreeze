using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2018

    public class DataClassificationVariable : Variable, IHasDimensions
    {
        public DataClassificationVariable(string name) : this(0, name)
        {
        }

        public DataClassificationVariable(int id, string name) : base(id, name)
        {
        }

        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.DataClassification;
    }

#endif
}