using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
		public class ItemNode : MenuSuiteNode
	{
		public ItemNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteItemNodeProperties(this);
		}

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
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
