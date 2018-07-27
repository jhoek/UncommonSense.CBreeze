using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class DataClassificationProperty : NullableValueProperty<DataClassification>
    {
        internal DataClassificationProperty(string name) : base(name)
        {
        }
    }
}