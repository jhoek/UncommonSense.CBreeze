using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace CBreeze.NextGen
{
	public abstract class Properties : IProperties, INode
	{
		internal Properties(Node parentNode)
		{
			ParentNode = parentNode;
		}

        public override string ToString()
        {
            return "Properties";
        }

		public IEnumerator<Property> GetEnumerator()
		{
			return ChildNodes.Cast<Property>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ChildNodes.Cast<Property>().GetEnumerator();
		}

		public Property this[string name]
		{
			get
			{
				return ChildNodes.Cast<Property>().FirstOrDefault(p => p.Name == name);
			}
		}

		public Node ParentNode
		{
			get;
			internal set;
		}

		public abstract IEnumerable<INode> ChildNodes
		{
			get;
		}
	}
}

