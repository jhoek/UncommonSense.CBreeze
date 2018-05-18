using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
    public class MenuSuites : IntegerKeyedAndNamedContainer<MenuSuite>, INode
    {
        internal MenuSuites(Application application, IEnumerable<MenuSuite> menuSuites)
        {
            Application = application;
            AddRange(menuSuites);
        }

        public Application Application { get; protected set; }
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;

        public override void ValidateName(MenuSuite item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}