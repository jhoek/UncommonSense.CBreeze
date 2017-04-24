using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    /// <summary>
    /// Abstract container for keyed items
    /// </summary>
    /// <typeparam name="TKey">The type of key, typically int or Guid. Needs to be a struct.</typeparam>
    /// <typeparam name="TItem">The type of item. Needs to derive from KeyedItem.</typeparam>
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

        public void AddRange(IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public new TItem Insert(int index, TItem item)
        {
            this.InsertItem(index, item);
            return item;
        }

        public T Insert<T>(int index, T item) where T : TItem
        {
            this.InsertItem(index, item);
            return item;
        }

        protected virtual void InitializeKey(TItem item)
        {
            item.ID = IsUninitializedKey(item.ID) ? GetNextAvailableKey() : item.ID;
        }

        protected override void InsertItem(int index, TItem item)
        {
            InitializeKey(item);
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
