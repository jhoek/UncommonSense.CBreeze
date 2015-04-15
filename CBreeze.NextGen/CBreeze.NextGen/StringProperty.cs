using System;

namespace CBreeze.NextGen
{
	public class StringProperty : ValueProperty<string>
	{
		internal StringProperty(string name)
			: base(name)
		{
		}

		public override bool HasValue
		{
			get
			{
				return Value != null;
			}
		}

	}
}

