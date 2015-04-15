using System;

namespace CBreeze.NextGen
{
	public class NullableDateTimeProperty : ValueProperty<DateTime?>
	{
		internal NullableDateTimeProperty(string name)
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

