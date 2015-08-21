using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    public abstract class KeyedItem<TKey>
    {
        public TKey ID
        {
            get;
            protected internal set;
        }
    }
}
