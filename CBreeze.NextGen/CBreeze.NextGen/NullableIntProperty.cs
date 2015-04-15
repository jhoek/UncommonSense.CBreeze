using System;

namespace CBreeze.NextGen
{
	public class NullableIntProperty : ValueProperty<int?>
	{
		internal NullableIntProperty(string name)
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

