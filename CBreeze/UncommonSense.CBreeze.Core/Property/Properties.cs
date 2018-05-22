using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Property
{
    public abstract class Properties : IProperties, INode
    {
        protected List<Implementation.Property> innerList = new List<Implementation.Property>();

        public T ByName<T>(string name) where T : Implementation.Property
        {
            return (this[name] as T);
        }

        public Implementation.Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

        public IEnumerable<Implementation.Property> WithAValue
        {
            get
            {
                return innerList.Where(p => p.HasValue);
            }
        }

        public abstract INode ParentNode
        {
            get;
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public IEnumerator<Implementation.Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
