using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Attributes : ObjectModelNode, IEnumerable<Attribute>
    {
        private List<Attribute> innerList = new List<Attribute>();

        public Attribute Add(Attribute attribute)
        {
            attribute.ParentNode = this;
            innerList.Add(attribute);
            return attribute;
        }

        public IEnumerator<Attribute> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
