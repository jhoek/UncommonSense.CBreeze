using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Container : ObjectModelElement
    {
        public Container(string itemTypeName, string name)
            : base(name)
        {
            ItemTypeName = itemTypeName;
        }

        public Item ItemType
        {
            get
            {
                return ObjectModel.Elements.OfType<Item>().FirstOrDefault(i => i.Name == ItemTypeName);
            }
        }

        public string ItemTypeName
        {
            get;
            internal set;
        }
    }
}
