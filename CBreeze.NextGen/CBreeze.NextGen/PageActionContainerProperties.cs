using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class PageActionContainerProperties : Properties
	{
		private NullableValueProperty<ActionContainerType> actionContainerType = new NullableValueProperty<ActionContainerType>("ActionContainerType");

		internal PageActionContainerProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public ActionContainerType? ActionContainerType
		{
			get
			{
				return actionContainerType.Value;
			}
			set
			{
				actionContainerType.Value = value;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return actionContainerType;		
			}
		}
	}
}

