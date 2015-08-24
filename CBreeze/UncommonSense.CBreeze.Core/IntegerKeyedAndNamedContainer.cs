using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class IntegerKeyedAndNamedContainer<TItem> : KeyedAndNamedContainer<int, TItem> where TItem : KeyedAndNamedItem<int>
    {
        protected override bool IsUninitializedKey(int key)
        {
            return key == 0;
        }

        protected override int GetNextAvailableKey()
        {
            return this.Any() ? this.Max(i => i.ID) + 1 : 1;
        }
    }
}
