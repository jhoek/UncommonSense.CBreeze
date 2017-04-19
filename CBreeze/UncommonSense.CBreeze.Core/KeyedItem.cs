using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    /// <summary>
    /// Abstract base class for keyed items.
    /// </summary>
    /// <typeparam name="TKey">Type of key. Needs to be a struct.</typeparam>
    public abstract class KeyedItem<TKey>  where TKey : struct
    {
        public TKey ID
        {
            get;
            protected internal set;
        }
    }
}
