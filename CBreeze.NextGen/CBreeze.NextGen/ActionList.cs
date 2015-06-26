using System;

namespace CBreeze.NextGen
{
	public class ActionList : KeyedContainer<int, PageActionBase>
	{
		// This parameterless constructor is required for allowing this
		// ActionList to be used in ActionListProperty. PageProperties
		// sets the ParentNode from its constructor.
		public ActionList()
			: base(null)
		{
		}

		public override string ToString()
		{
			return "ActionList";
		}
	}
}

