using System;

namespace CBreeze.NextGen
{
	public class Reports : Container<int, Report>
	{
		internal Reports(Node parentNode, params Report[] reports)
			: base(parentNode, reports)
		{
		}

		public override string ToString()
		{
			return "Reports";
		}
	}
}

