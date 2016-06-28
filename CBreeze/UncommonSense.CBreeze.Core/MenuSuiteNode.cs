using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public abstract class MenuSuiteNode : KeyedItem<Guid>, IHasName, IHasProperties
	{
		internal MenuSuiteNode(Guid id)
		{
			ID = id;
		}

		public abstract MenuSuiteNodeType Type
		{
			get;
		}

		public MenuSuiteNodes Container
		{
			get;
			internal set;
		}

		public abstract string GetName();

		public abstract Properties AllProperties
		{
			get;
		}

		public int Index
		{
			get
			{
				return Container.IndexOf(this);
			}
		}
	}
}
