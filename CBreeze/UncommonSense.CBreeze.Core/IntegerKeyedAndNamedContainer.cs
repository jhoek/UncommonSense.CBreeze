using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class IntegerKeyedAndNamedContainer<TItem> : KeyedAndNamedContainer<int, TItem> where TItem : KeyedItem<int>, IHasName
    {
        public virtual IEnumerable<int> ExistingIDs => this.Select(i => i.ID);

        public IEnumerable<int> Range
        {
            get;
            set;
        }

        protected abstract IEnumerable<int> DefaultRange { get; }

        protected override int GetNextAvailableKey() => (Range ?? DefaultRange).Except(ExistingIDs).First();

        protected override bool IsUninitializedKey(int key)
        {
            return key == 0;
        }
    }
}