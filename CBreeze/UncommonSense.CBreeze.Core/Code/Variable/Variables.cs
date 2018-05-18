using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public abstract class Variables : IntegerKeyedAndNamedContainer<Variable>, INode
    {
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID);
        public abstract INode ParentNode { get; }

        public override void ValidateName(Variable item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}