using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public class GroupNode : MenuSuiteNode
	{
		public GroupNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteGroupNodeProperties();
		}

		public override MenuSuiteNodeType Type
		{
			get
			{
				return MenuSuiteNodeType.MenuGroup;
			}
		}

		public MenuSuiteGroupNodeProperties Properties
		{
			get;
			protected set;
		}

		public override Properties AllProperties
		{
			get
			{
				return Properties;
			}
		}

		public override string GetName()
		{
			return Properties.Name;
		}
	}
}
