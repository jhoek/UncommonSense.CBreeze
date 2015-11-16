﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class UpdatePropagationProperty : NullableValueProperty<UpdatePropagation>
    {
        internal UpdatePropagationProperty(string name)
            : base(name)
        {
        }
    }
}
