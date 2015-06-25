using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public abstract class Node : INode
	{
		public Node ParentNode
		{
			get;
			internal set;
		}

		public virtual IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break;
			}
		}
	}
}
