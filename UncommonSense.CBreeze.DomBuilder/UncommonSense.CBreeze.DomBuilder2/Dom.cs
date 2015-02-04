using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Dom : INode
    {
        private string @namespace;
        private List<DomChildNode> childNodes = new List<DomChildNode>();

        public Dom(string @namespace, params DomChildNode[] childNodes)
        {
            this.@namespace = @namespace;

            foreach (var childNode in childNodes)
            {
                childNode.Dom = this;
                this.childNodes.Add(childNode);
            }
        }

        public override string ToString()
        {
            return string.Format("Dom {0}", Namespace);
        }

        public string Namespace
        {
            get
            {
                return this.@namespace;
            }
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                return this.childNodes;
            }
        }
    }
}
