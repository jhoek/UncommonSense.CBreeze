using System;
using System.Linq;

namespace CBreeze.NextGen
{
	public class ActionListProperty : ReferenceProperty<ActionList>
	{
		public ActionListProperty(string name)
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

