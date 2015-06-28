using System;

namespace CBreeze.NextGen
{
	public class BooleanTableFieldProperties : Properties
	{
		internal BooleanTableFieldProperties(Node parentNode)
			: base(parentNode)
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

