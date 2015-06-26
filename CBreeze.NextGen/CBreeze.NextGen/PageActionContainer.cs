using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class PageActionContainer : PageActionBase
	{
		public PageActionContainer(int id, string name, int? indentationLevel)
			: base(id, name, indentationLevel)
		{
			Properties = new PageActionContainerProperties(this);
		}

		public PageActionContainerProperties Properties
		{
			get;
			internal set;
		}

		public override PageActionType Type
		{
			get
			{
				return PageActionType.Container;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Properties;
			}
		}
	}
}

