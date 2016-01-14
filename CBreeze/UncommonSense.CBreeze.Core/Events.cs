using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Events : Collection<Event>
    {
        internal Events(Code code)
        {
            Code = code;
        }

        public Code Code
        {
            get;
            protected set;
        }

        protected override void InsertItem(int index, Event item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }

        public new Event Add(Event item)
        {
            base.Add(item);
            return item;
        }
    }
}
