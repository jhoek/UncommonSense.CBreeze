using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class CodeunitProperties : Properties
	{
		internal CodeunitProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break; // FIXME
			}
		}
	}
}

