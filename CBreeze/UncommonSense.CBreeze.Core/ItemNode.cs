using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class ItemNode : MenuSuiteNode
	{
		public ItemNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteItemNodeProperties();
		}

		public override MenuSuiteNodeType Type
		{
			get
			{
				return MenuSuiteNodeType.MenuItem;
			}
		}

		public MenuSuiteItemNodeProperties Properties
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
