using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MenuSuiteNodes : IEnumerable<MenuSuiteNode>
    {
        private Dictionary<Guid,MenuSuiteNode> innerList = new Dictionary<Guid,MenuSuiteNode>();

        internal MenuSuiteNodes()
        {
        }

        public DeltaNode AddDeltaNode(Guid id)
        {
            DeltaNode item = new DeltaNode(id);
            innerList.Add(id, item);
            return item;
        }

        public GroupNode AddGroupNode(Guid id)
        {
            GroupNode item = new GroupNode(id);
            innerList.Add(id, item);
            return item;
        }

        public ItemNode AddItemNode(Guid id)
        {
            ItemNode item = new ItemNode(id);
            innerList.Add(id, item);
            return item;
        }

        public MenuNode AddMenuNode(Guid id)
        {
            MenuNode item = new MenuNode(id);
            innerList.Add(id, item);
            return item;
        }

        public RootNode AddRootNode(Guid id)
        {
            RootNode item = new RootNode(id);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Guid id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<MenuSuiteNode> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
