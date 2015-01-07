using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public interface INode
	{
		IEnumerable<INode> ChildNodes
		{ 
			get;
		}
	}
}

