using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    public abstract class KeyedAndNamedItem<T> : KeyedItem<T>
    {
        public abstract string GetName();
    }
}
