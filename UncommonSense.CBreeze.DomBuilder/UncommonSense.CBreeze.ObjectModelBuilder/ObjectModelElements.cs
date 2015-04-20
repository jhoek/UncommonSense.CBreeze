using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class ObjectModelElements :  IEnumerable<ObjectModelElement>
    {
        private List<ObjectModelElement> innerList = new List<ObjectModelElement>();

        internal ObjectModelElements(ObjectModel objectModel)
        {
            ObjectModel = objectModel;
        }

        public T Add<T>(T item) where T : ObjectModelElement
        {
            item.ObjectModel = ObjectModel;
            innerList.Add(item);
            return item;
        }

        public ObjectModel ObjectModel
        {
            get;
            internal set;
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
