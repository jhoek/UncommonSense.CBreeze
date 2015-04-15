using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class FieldList : List<int>
	{
		public override string ToString()
		{
			return string.Join(",", this.Select(f => f.ToString()));
		}
	}
}

