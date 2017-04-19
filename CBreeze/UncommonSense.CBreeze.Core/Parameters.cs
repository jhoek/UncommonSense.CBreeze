using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
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