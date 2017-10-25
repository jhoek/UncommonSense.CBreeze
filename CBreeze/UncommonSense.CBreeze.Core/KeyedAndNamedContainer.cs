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
        public TItem this[string name]
        {
            get
            {
                return this.Items.FirstOrDefault(i => i.GetName() == name);
            }
        }

        public abstract void ValidateName(TItem item);

        protected override void InsertItem(int index, TItem item)
        {
            ValidateName(item);
            base.InsertItem(index, item);
        }

        protected virtual void TestNameNotNullOrEmpty(TItem item)
        {
            if (string.IsNullOrEmpty(item.GetName()))
                throw new ArgumentOutOfRangeException("Collection items must have a name.");
        }

        protected virtual void TestNameUnique(TItem item)
        {
            var newName = item.GetName();

            if (string.IsNullOrEmpty(newName))
                return;

            var existingNames =
                this
                    .Select(i => i.GetName())
                    .Where(n => !string.IsNullOrEmpty(n));

            if (existingNames.Any(n => n.Equals(newName, StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentOutOfRangeException("Collection item names must be unique.");
        }
    }
}