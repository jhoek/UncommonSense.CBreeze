using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    // FIXME: GetNextAvailableKey should be implemented for each descendent class, e.g. based on the 
    // object ID range.

    public abstract class IntegerKeyedAndNamedContainer<TItem> : KeyedAndNamedContainer<int, TItem> where TItem : KeyedItem<int>, IHasName
    {
        protected override bool IsUninitializedKey(int key)
        {
            return key == 0;
        }

        // FIXmE: later: (Range ?? ParentRange).Except(ExistingIDs).First();
        protected override int GetNextAvailableKey() => Range.Except(ExistingIDs).First();

        public virtual IEnumerable<int> ExistingIDs => this.Select(i => i.ID);

        // FIXME: Later: protected abstract IEnumerable<int> ParentRange { get; }

        public IEnumerable<int> Range
        {
            get;
            set;
        }
    }
}
