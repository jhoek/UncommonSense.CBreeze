using System;

namespace CBreeze.NextGen
{
	public class Reports : KeyedContainer<int, Report>
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

