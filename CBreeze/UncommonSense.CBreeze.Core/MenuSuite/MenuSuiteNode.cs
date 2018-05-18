using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Generic;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
		public abstract class MenuSuiteNode : KeyedItem<Guid>, IHasName, IHasProperties, INode
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

        public INode ParentNode => Container;

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }
    }
}
