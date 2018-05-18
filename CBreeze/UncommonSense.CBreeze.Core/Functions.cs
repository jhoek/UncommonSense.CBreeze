using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Functions : IntegerKeyedAndNamedContainer<Function>, INode
    {
        internal Functions(Code code)
        {
            Code = code;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public Code Code
        {
            get;
            protected set;
        }

        public INode ParentNode => Code;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(Function item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Function item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }
    }
}