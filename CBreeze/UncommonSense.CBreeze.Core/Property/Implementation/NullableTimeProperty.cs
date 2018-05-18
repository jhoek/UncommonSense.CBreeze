using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class NullableTimeProperty : NullableValueProperty<TimeSpan>
	{
		internal NullableTimeProperty(string name)
			: base(name)
		{
		}
	}
}
