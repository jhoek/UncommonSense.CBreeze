using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class Node
    {
        private Node parentNode;
        private Dom dom;
        private Nodes childNodes = new Nodes();

        public abstract string Name
        {
            get;
        }

        public Node ParentNode
        {
            get
            {
                return this.parentNode;
            }
            internal set
            {
                this.parentNode = value;
            }
        }

        public Dom Dom
        {
            get
            {
                return this.dom;
            }
            internal set
            {
                this.dom = value;
            }
        }

        public Nodes ChildNodes
        {
            get
            {
                return this.childNodes;
            }
        }
    }
}
