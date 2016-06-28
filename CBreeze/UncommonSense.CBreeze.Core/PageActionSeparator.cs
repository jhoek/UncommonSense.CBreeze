using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class PageActionSeparator : PageActionBase
	{
		public PageActionSeparator(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new PageActionSeparatorProperties();
		}

		public override PageActionBaseType Type
		{
			get
			{
				return PageActionBaseType.Separator;
			}
		}

		public PageActionSeparatorProperties Properties
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
