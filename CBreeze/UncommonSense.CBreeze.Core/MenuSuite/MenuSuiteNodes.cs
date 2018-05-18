using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
        public class MenuSuiteNodes : GuidKeyedContainer<MenuSuiteNode>, INode
    {
        internal MenuSuiteNodes(MenuSuite menuSuite)
        {
            MenuSuite = menuSuite;
        }

        public MenuSuite MenuSuite
        {get;protected set;
        }

        public INode ParentNode => MenuSuite;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        protected override void InsertItem(int index, MenuSuiteNode item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }
        
        protected override void InitializeKey(MenuSuiteNode item)
        {
            // Do not auto-assign Guids to root nodes; they should be Guid.Empty
            if (item is RootNode)
                return;

            base.InitializeKey(item);
        }
    }
}
