using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Container : Node
    {
        private string name;
        private string itemTypeName;

        public Container(string itemTypeName, string name = null)
        {
            this.itemTypeName = itemTypeName;
            this.name = name;
        }

        public override string Name
        {
            get
            {
                return this.name ?? ItemTypeName + "s";
            }
        }

        public string ItemTypeName
        {
            get
            {
                return this.itemTypeName;
            }
        }
    }
}
