using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class ObjectModelElements : ObjectModelNode, IEnumerable<ObjectModelElement>
    {
        private List<ObjectModelElement> innerList = new List<ObjectModelElement>();

        internal ObjectModelElements(ObjectModel objectModel)
        {
            ParentNode = objectModel;
        }

        public ObjectModelElement Add(ObjectModelElement item)
        {
            item.ParentNode = this;
            innerList.Add(item);
            return item;
        }

        public IEnumerator<ObjectModelElement> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
