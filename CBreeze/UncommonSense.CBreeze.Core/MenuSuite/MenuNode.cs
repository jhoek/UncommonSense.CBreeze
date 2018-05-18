using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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
