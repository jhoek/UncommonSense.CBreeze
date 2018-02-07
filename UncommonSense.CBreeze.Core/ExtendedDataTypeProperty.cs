using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class ExtendedDataTypeProperty : NullableValueProperty<ExtendedDataType>
	{
		internal ExtendedDataTypeProperty(string name)
			: base(name)
		{
		}
	}
}
