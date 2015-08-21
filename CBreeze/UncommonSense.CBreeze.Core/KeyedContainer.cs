using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    public abstract class KeyedContainer<TKey, TItem> : KeyedCollection<TKey, TItem>
        where TItem : KeyedItem<TKey>
        where TKey : struct
    {
        public new TItem Add(TItem item)
        {
            this.InsertItem(Count, item);
            return item;
        }

        public T Add<T>(T item) where T : TItem
        {
            this.InsertItem(Count, item);
            return item;
        }

        protected override void InsertItem(int index, TItem item)
        {
            item.ID = IsUninitializedKey(item.ID) ? GetNextAvailableKey() : item.ID;

            base.InsertItem(index, item);
        }

        protected override TKey GetKeyForItem(TItem item)
        {
            return (TKey)item.ID;
        }

        protected abstract bool IsUninitializedKey(TKey key);

        protected abstract TKey GetNextAvailableKey();
    }
}
