using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public class GestureProperty : NullableValueProperty<Gesture>
    {
        public GestureProperty(string name) 
            : base(name)
        {
        }
    }
}
