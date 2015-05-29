using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Properties : ObjectModelElement, IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        public Properties(string name)
            : base(name)
        {
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
