using System;

namespace CBreeze.NextGen
{
	public class NullableBoolProperty : ValueProperty<bool?>
	{
		internal NullableBoolProperty(string name)
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

