using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public abstract class Parameters : IntegerKeyedAndNamedContainer<Parameter>, INode
    {
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public abstract INode ParentNode { get; }
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(Parameter item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}