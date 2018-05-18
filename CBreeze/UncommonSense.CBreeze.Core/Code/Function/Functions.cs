using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Function
{
    public class Functions : IntegerKeyedAndNamedContainer<Variable.Function>, INode
    {
        internal Functions(Variable.Code code)
        {
            Code = code;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public Variable.Code Code
        {
            get;
            protected set;
        }

        public INode ParentNode => Code;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(Variable.Function item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Variable.Function item)
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