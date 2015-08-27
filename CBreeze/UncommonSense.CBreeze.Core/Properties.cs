using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class Properties : IProperties
    {
        protected List<Property> innerList = new List<Property>();

        public T ByName<T>(string name) where T : Property
        {
            return (this[name] as T);
        }

        public Property this[string name]
        {
            get
            {
                return innerList.FirstOrDefault(p => p.Name == name);
            }
        }

        public IEnumerable<Property> WithAValue
        {
            get
            {
                return innerList.Where(p => p.HasValue);
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
