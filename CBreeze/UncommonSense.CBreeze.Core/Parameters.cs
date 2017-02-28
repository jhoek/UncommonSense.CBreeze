using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Parameters : IntegerKeyedAndNamedContainer<Parameter>, INode
    {
        internal Parameters(IHasParameters container)
        {
            Container = container;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public IHasParameters Container
        {
            get;
            protected set;
        }

        public INode ParentNode => Container;

        public override void ValidateName(Parameter item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
