using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Variables : IntegerKeyedAndNamedContainer<Variable>, INode
    {
        internal Variables(IHasVariables container)
        {
            Container = container;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public IHasVariables Container
        {
            get;
            protected set;
        }

        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID);
        public INode ParentNode => Container;

        // FIXME: ook parameters
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        protected override bool UseAlternativeRange => (Range ?? AlternativeRange).Contains(Container.ID);

        public override void ValidateName(Variable item)
        {
            TestNameNotNullOrEmpty(item);
        }
    }
}