using System;

namespace CBreeze.NextGen
{
	public class PageControls : KeyedContainer<int, PageControl>
	{
		internal PageControls(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Controls";
		}
	}
}

