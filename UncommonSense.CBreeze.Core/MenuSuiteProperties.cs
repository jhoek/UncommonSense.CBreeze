using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class MenuSuiteProperties : Properties
    {
        internal MenuSuiteProperties(MenuSuite menuSuite)
        {
            MenuSuite = menuSuite;
        }

        public MenuSuite MenuSuite { get; protected set; }

        public override INode ParentNode => MenuSuite;
    }
}
