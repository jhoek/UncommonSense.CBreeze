using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Item : ObjectModelElement
    {
        public Item(string name)
            : base(name)
        {
            Attributes = new List<Attribute>();
        }

        public List<Attribute> Attributes
        {
            get;
            internal set;
        }
    }
}
