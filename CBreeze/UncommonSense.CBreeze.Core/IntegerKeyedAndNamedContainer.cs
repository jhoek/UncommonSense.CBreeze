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

		protected override int GetNextAvailableKey()
		{
			return this.Any() ? this.Max(i => i.ID) + 1 : 1;
		}
	}
}
