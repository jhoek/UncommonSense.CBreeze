using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class RootNode : MenuSuiteNode
	{
		public RootNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteRootNodeProperties();
		}

		public override MenuSuiteNodeType Type
		{
			get
			{
				return MenuSuiteNodeType.Root;
			}
		}

		public MenuSuiteRootNodeProperties Properties
		{
			get;
			protected set;
		}

		public override string GetName()
		{
			return null;
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
