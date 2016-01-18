using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class PageAction : PageActionBase
	{
		public PageAction(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new PageActionProperties();
		}

		public override PageActionBaseType Type
		{
			get
			{
				return PageActionBaseType.Action;
			}
		}

		public PageActionProperties Properties
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
