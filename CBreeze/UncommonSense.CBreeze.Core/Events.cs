using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
        public class Events : Collection<Event>, INode
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

        public INode ParentNode => Code;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

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
