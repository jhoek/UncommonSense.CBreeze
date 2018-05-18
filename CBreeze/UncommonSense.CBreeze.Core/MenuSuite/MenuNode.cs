using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.MenuSuite
{
		public class MenuNode : MenuSuiteNode
	{
		public MenuNode(Guid id)
			: base(id)
		{
			Properties = new MenuSuiteMenuNodeProperties(this);
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
