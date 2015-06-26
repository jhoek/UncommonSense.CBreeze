using System;

namespace CBreeze.NextGen
{
	public class BigIntegerTableFieldProperties : Properties
	{
		public BigIntegerTableFieldProperties(Node parentNode) : base(parentNode)
		{
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break; // FIXME
			}
		}
	}
}

