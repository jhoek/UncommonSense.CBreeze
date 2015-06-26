using System;
using System.Linq;

namespace CBreeze.NextGen
{
	public class PermissionsProperty : ReferenceProperty<Permissions>
	{
		internal PermissionsProperty()
			: base("Permissions")
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

