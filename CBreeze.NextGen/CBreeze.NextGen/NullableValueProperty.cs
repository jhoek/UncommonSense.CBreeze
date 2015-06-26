using System;

namespace CBreeze.NextGen
{
	public class NullableValueProperty<T> : ValueProperty<T?> where T : struct
	{
		public NullableValueProperty(string name)
			: base(name, (v) => {
				return v.HasValue;
			})
		{
		}
	}
}

