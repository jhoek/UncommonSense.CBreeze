using System;

namespace CBreeze.NextGen
{
	public class Pages : Container<int, Page>
	{
		internal Pages(Node parentNode, params Page[] pages)
			: base(parentNode, pages)
		{
		}

		public override string ToString()
		{
			return "Pages";
		}
	}
}

