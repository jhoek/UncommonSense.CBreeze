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
            Attributes = new Attributes();
        }

        public Attributes Attributes
        {
            get;
            internal set;
        }

        public string BaseTypeName
        {
            get;
            set;
        }
    }
}
