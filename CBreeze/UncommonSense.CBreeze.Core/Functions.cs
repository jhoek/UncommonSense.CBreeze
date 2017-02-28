using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Functions : IntegerKeyedAndNamedContainer<Function>, INode
    {
        internal Functions(Code code)
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

        protected override void InsertItem(int index, Function item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }

        public override void ValidateName(Function item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
