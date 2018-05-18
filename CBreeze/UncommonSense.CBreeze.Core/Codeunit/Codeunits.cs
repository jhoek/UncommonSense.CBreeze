using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Codeunit
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

        public override void ValidateName(Codeunit item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}