using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BlobTableFieldProperties : Properties
	{
		internal BlobTableFieldProperties(Node parentNode)
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

