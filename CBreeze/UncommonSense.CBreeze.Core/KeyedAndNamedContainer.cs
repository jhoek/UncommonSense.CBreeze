using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    public delegate void NameValidator<TKey, TItem>(TItem item, KeyedAndNamedContainer<TKey, TItem> container)
        where TItem : KeyedAndNamedItem<TKey>
        where TKey : struct;

    public abstract class KeyedAndNamedContainer<TKey, TItem> : KeyedContainer<TKey, TItem>
        where TItem : KeyedAndNamedItem<TKey>
        where TKey : struct
    {
        public KeyedAndNamedContainer(NameValidator<TKey, TItem> nameValidator)
        {
            NameValidator = nameValidator;
        }

        protected override void InsertItem(int index, TItem item)
        {
            NameValidator(item, this);
            base.InsertItem(index, item);
        }

        public TItem this[string name]
        {
            get
            {
                return this.Items.FirstOrDefault(i => i.GetName() == name);
            }
        }

        public NameValidator<TKey, TItem> NameValidator
        {
            get;
            protected set;
        }
    }
}
