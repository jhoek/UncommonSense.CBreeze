using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class GroupPageControl : PageControl
	{
		public GroupPageControl(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new GroupPageControlProperties();
            Properties.ActionList.Page = Container.Page;
		}

		public override PageControlType Type
		{
			get
			{
				return PageControlType.Group;
			}
		}

		public GroupPageControlProperties Properties
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
