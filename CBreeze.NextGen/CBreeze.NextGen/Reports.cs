using System;

namespace CBreeze.NextGen
{
	public class Reports : Container<int, Report>
	{
		internal Reports(Node parentNode) : base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Reports";
		}
	}
}

