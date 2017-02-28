using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Variables : IntegerKeyedAndNamedContainer<Variable>, INode
    {
        internal Variables(IHasVariables container)
        {
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public IHasVariables Container
        {
            get;
            protected set;
        }

        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID); // FIXME: ook parameters

        public INode ParentNode => Container;

        public override void ValidateName(Variable item)
        {
            TestNameNotNullOrEmpty(item);
        }
    }
}
