using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace CBreeze.NextGen
{
    public abstract class Properties : IProperties, INode
    {
        private Node parentNode;

        internal Properties(Node parentNode)
        {
            this.parentNode = parentNode;
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return ChildNodes.Cast<Property>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ChildNodes.Cast<Property>().GetEnumerator();
        }

        public Node ParentNode
        {
            get
            {
                return this.parentNode;
            }
        }

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }
    }
}

