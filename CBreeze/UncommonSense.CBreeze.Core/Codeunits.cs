using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Codeunits : IntegerKeyedAndNamedContainer<Codeunit>, INode
    {
        internal Codeunits(Application application, IEnumerable<Codeunit> codeunits)
        {
            Application = application;
            AddRange(codeunits);
        }

        public Application Application { get; protected set; }
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        protected override bool UseAlternativeRange => false;

        public override void ValidateName(Codeunit item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}