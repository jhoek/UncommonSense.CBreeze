using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class PageControls : IEnumerable<PageControl>
    {
        private Dictionary<Int32,PageControl> innerList = new Dictionary<Int32,PageControl>();

        internal PageControls()
        {
        }

        public ContainerPageControl AddContainerPageControl(Int32 id, Int32? indentationLevel)
        {
            ContainerPageControl item = new ContainerPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public FieldPageControl AddFieldPageControl(Int32 id, Int32? indentationLevel)
        {
            FieldPageControl item = new FieldPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public GroupPageControl AddGroupPageControl(Int32 id, Int32? indentationLevel)
        {
            GroupPageControl item = new GroupPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PartPageControl AddPartPageControl(Int32 id, Int32? indentationLevel)
        {
            PartPageControl item = new PartPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<PageControl> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
