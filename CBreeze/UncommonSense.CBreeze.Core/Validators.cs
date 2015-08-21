using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    public static class Validators
    {
        public static void NameRequiredAndUnique<TKey, TItem>(TItem item, KeyedAndNamedContainer<TKey, TItem> container)
            where TItem : KeyedAndNamedItem<TKey>
            where TKey : struct
        {
            if (string.IsNullOrEmpty(item.GetName()))
                throw new ApplicationException("Name cannot be null or empty.");

            if (container.Any(i => i.GetName() == item.GetName()))
                throw new ApplicationException("Name must be unique within collection.");
        }

        public static void NameOptionalAndUnique<TKey, TItem>(TItem item, KeyedAndNamedContainer<TKey, TItem> container)
            where TItem : KeyedAndNamedItem<TKey>
            where TKey : struct
        {
            if (!string.IsNullOrEmpty(item.GetName()))
                if (container.Any(i => i.GetName() == item.GetName()))
                    throw new ApplicationException("Name must be unique within collection.");
        }
    }
}
