using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class GuidKeyedContainer<TItem> : KeyedContainer<Guid, TItem> where TItem : KeyedItem<Guid>
    {
        protected override bool IsUninitializedKey(Guid key)
        {
            return key == Guid.Empty;
        }

        protected override Guid GetNextAvailableKey()
        {
            return Guid.NewGuid();
        }
    }
}
