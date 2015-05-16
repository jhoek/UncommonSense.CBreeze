using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public abstract class Container<T> : Node, IEnumerable<T> where T : Node
    {
        private List<T> innerList = new List<T>();

        internal Container(Node parentNode)
        {
            ParentNode = parentNode;
        }

        public override string ToString()
        {
            return "Container";
        }

        public TItem Add<TItem>(TItem item) where TItem : T
        {
            item.ParentNode = ParentNode;
            innerList.Add(item);
            return item;
        }

        public bool Remove(T item)
        {
            return innerList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public void Clear()
        {
            innerList.Clear();
        }

        public T this[int index]
        {
            get
            {
                return innerList[index];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                foreach (var item in innerList)
                {
                    yield return item;
                }   
            }
        }
    }
}
