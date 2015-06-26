using System;

namespace CBreeze.NextGen
{
	public class StringProperty : ValueProperty<string>
	{
		internal StringProperty(string name)
			: base(name, (v) => {
				return v != null;
			})
		{
		}
	}
}

