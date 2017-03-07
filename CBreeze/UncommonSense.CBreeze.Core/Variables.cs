using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public abstract class Variables : IntegerKeyedAndNamedContainer<Variable>, INode
    {
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID);
        public abstract INode ParentNode { get; }

        // FIXME: ook parameters
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(Variable item)
        {
            TestNameNotNullOrEmpty(item);
        }
    }
}