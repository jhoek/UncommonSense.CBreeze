using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
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
