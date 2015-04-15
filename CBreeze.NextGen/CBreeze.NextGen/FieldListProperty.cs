using System;
using System.Linq;

namespace CBreeze.NextGen
{
	public class FieldListProperty : ReferenceProperty<FieldList>
	{
		public FieldListProperty(string name) : base(name)
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

