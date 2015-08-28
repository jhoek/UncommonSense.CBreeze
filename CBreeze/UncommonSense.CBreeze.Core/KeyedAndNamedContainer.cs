using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
	public abstract class KeyedAndNamedContainer<TKey, TItem> : KeyedContainer<TKey, TItem>
		where TItem : KeyedItem<TKey>, IHasName
        where TKey : struct
	{
		protected override void InsertItem(int index, TItem item)
		{
			ValidateName(item);
			base.InsertItem(index, item);
		}

		public TItem this [string name]
		{
			get
			{
				return this.Items.FirstOrDefault(i => i.GetName() == name);
			}
		}

		public abstract void ValidateName(TItem item);

		protected void TestNameNotNullOrEmpty(TItem item)
		{
			if (string.IsNullOrEmpty(item.GetName()))
				throw new ArgumentOutOfRangeException("Collection items must have a name.");
		}

		protected void TestNameUnique(TItem item)
		{
			if (!string.IsNullOrEmpty(item.GetName()))
			{
				if (this.Any(i => i.GetName() == item.GetName()))
					throw new ArgumentOutOfRangeException("Collection item names must be unique.");
			}
		}
	}
}
