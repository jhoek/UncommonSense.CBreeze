using System;

namespace CBreeze.NextGen
{
	public class MinOccursProperty : ValueProperty<MinOccurs?>
	{
		internal MinOccursProperty(string name)
			: base(name)
		{
		}

		public override bool HasValue
		{
			get
			{
				return Value.HasValue;
			}
		}
	}
}

