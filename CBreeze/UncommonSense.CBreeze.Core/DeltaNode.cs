using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public class DeltaNode : MenuSuiteNode
	{
		public DeltaNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteDeltaNodeProperties();
		}

		public override MenuSuiteNodeType Type
		{
			get
			{
				return MenuSuiteNodeType.Delta;
			}
		}

		public MenuSuiteDeltaNodeProperties Properties
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
			return null;
		}
	}
}
