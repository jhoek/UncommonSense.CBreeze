using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Attribute : ItemElement
    {
        private bool isIdentifier; // FIXME: This attribute is part of the item's "primary key"

        public Attribute(string name)
            : base(name)
        {
        }
    }
}
