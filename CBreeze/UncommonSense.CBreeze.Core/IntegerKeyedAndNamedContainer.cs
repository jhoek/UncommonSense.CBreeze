using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class IntegerKeyedAndNamedContainer<TItem> : KeyedAndNamedContainer<int, TItem> where TItem : KeyedItem<int>, IHasName
    {
        public virtual IEnumerable<int> AlternativeRange => Enumerable.Range(1, int.MaxValue);

        public virtual IEnumerable<int> ExistingIDs => this.Select(i => i.ID);

        public IEnumerable<int> Range { get; set; }

        protected abstract IEnumerable<int> DefaultRange { get; }
        protected virtual bool UseAlternativeRange => false;

        protected IEnumerable<int> EffectiveRange => 
            Range ?? (UseAlternativeRange ? AlternativeRange : DefaultRange);

        protected override int GetNextAvailableKey()
        {
            try
            {
                return EffectiveRange.Except(ExistingIDs).First();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException($"No available IDs remain in the given range ({EffectiveRange.Min()}..{EffectiveRange.Max()}).", e);
            }
        }

        protected override bool IsUninitializedKey(int key) => key == 0;
    }
}