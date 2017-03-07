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

        // FIXME: INclude variables in public override IEnumerable<int> ExistingIDs
        public IHasParameters Container
        {
            get;
            protected set;
        }

        public INode ParentNode => Container;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;
        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Container.ID);

        public override void ValidateName(Parameter item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}