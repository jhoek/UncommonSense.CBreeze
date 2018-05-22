using System;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Base
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
