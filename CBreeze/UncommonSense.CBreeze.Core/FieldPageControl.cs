using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
		public class FieldPageControl : PageControl
	{
		public FieldPageControl(int id, int? indentationLevel)
			: base(id, indentationLevel)
		{
			Properties = new FieldPageControlProperties();
		}

		public override PageControlType Type
		{
			get
			{
				return PageControlType.Field;
			}
		}

		public FieldPageControlProperties Properties
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
