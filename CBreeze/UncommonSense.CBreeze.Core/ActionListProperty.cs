using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public class ActionListProperty : ReferenceProperty<ActionList>
	{
		internal ActionListProperty(string name)
			: base(name)
		{
		}

		public override bool HasValue
		{
			get
			{
				return Value.Any();
			}
		}
	}
}
