﻿using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;

namespace UncommonSense.CBreeze.Core.Base
{
    public abstract class IntegerKeyedAndNamedContainer<TItem> : KeyedAndNamedContainer<int, TItem> where TItem : KeyedItem<int>, IHasName
    {
        public virtual IEnumerable<int> AlternativeRange => Enumerable.Range(1, int.MaxValue);

        public virtual IEnumerable<int> ExistingIDs => this.Select(i => i.ID);

        public IEnumerable<int> Range { get; set; }

        protected abstract IEnumerable<int> DefaultRange { get; }
        protected virtual bool UseAlternativeRange => false;

        protected override int GetNextAvailableKey() => (Range ?? (UseAlternativeRange ? AlternativeRange : DefaultRange)).Except(ExistingIDs).First();

        protected override bool IsUninitializedKey(int key) => key == 0;
    }
}