using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
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

        public override void ValidateName(MenuSuite item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
