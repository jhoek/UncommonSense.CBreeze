using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class MenuNode : MenuSuiteNode
	{
		public MenuNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteMenuNodeProperties();
		}

		public override MenuSuiteNodeType Type
		{
			get
			{
				return MenuSuiteNodeType.Menu;
			}
		}

		public MenuSuiteMenuNodeProperties Properties
		{
			get;
			protected set;
		}

		public override string GetName()
		{
			return Properties.Name;
		}

		public override Properties AllProperties
		{
			get
			{
				return Properties;
			}
		}
	}
}
