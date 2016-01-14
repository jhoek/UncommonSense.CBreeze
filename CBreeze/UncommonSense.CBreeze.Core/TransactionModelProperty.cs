using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TransactionModelProperty : NullableValueProperty<TransactionModel>
    {
        internal TransactionModelProperty(string name)
            : base(name)
        {
        }
    }
}
