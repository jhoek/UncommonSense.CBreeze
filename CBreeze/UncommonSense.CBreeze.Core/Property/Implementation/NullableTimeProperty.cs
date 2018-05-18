using System;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
		public class NullableTimeProperty : NullableValueProperty<TimeSpan>
	{
		internal NullableTimeProperty(string name)
			: base(name)
		{
		}
	}
}
