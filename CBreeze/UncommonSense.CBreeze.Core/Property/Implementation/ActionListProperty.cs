using System.Linq;
using UncommonSense.CBreeze.Core.Page.Action;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
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
