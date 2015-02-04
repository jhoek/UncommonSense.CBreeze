using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Item : DomChildNode
    {
        [Flags()]
        public enum Options
        {
            None = 0,
            ChildNode=1,
            Abstract = 2,
            AutoCollection = 4
        }

        private Dom dom;
        private string name;
        private string baseTypeName;
        private Options options;
        private List<IChildNodeOfItem> childNodes = new List<IChildNodeOfItem>();

        public Item(string name, string baseTypeName, Options options, params IChildNodeOfItem[] childNodes)
        {
            this.name = name;
            this.baseTypeName = baseTypeName;
            this.options = options;
            this.childNodes.AddRange(childNodes);
        }

        public override string ToString()
        {
            return string.Format("Item {0}{1}", Name, BaseTypeName == null ? string.Empty : string.Format(" : {0}", BaseTypeName));
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string BaseTypeName
        {
            get
            {
                return this.baseTypeName;
            }
        }

        public bool Abstract
        {
            get
            {
                return this.options.HasFlag(Options.Abstract);
            }
        }

        public bool AutoCollection
        {
            get
            {
                return this.options.HasFlag(Options.AutoCollection);
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                return this.childNodes;
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
