using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Import :  DomChildNode
    {
        private Dom dom;
        private string @namespace;

        public Import(string @namespace)
        {
            this.@namespace = @namespace;
        }

        public string Namespace
        {
            get
            {
                return this.@namespace;
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
