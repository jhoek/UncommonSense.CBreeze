using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
		public class GroupNode : MenuSuiteNode
	{
		public GroupNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteGroupNodeProperties(this);
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
