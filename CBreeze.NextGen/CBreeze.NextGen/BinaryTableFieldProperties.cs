using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BinaryTableFieldProperties : Properties
	{
		internal BinaryTableFieldProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break;
			}
		}
	}
}

