using System;

namespace CBreeze.NextGen
{
	public class ActionList : KeyedContainer<int, PageActionBase>
	{
		public ActionList(Node parentNode)
			: base(parentNode)
		{
		}
	}
}

