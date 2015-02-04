using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Collection : DomChildNode
    {
        private Dom dom;
        private string name;
        private string itemTypeName;

        public Collection(string name, string itemTypeName)
        {
            this.name = name;
            this.itemTypeName = itemTypeName;
        }

        public override string ToString()
        {
            return string.Format("Collection {0} of item type {1}", Name, ItemTypeName);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string ItemTypeName
        {
            get
            {
                return this.itemTypeName;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public Dom Dom
        {
            get
            {
                return this.dom;
            }
            set
            {
                this.dom = value;
            }
        }
    }
}
