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
			get;
			internal set;
		}

		public abstract IEnumerable<INode> ChildNodes
		{
			get;
		}
	}
}

