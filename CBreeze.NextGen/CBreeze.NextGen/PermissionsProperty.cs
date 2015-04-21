using System;
using System.Linq;

namespace CBreeze.NextGen
{
	public class PermissionsProperty : ReferenceProperty<Permissions>
	{
		internal PermissionsProperty(string name)
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

