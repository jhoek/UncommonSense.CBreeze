using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public abstract class Node : INode
    {
        private Node parentNode;

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

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }
    }
}
