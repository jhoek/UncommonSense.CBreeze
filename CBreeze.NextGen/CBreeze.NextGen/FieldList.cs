using System;
using System.Linq;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class FieldList : List<int>
	{
		// Public parameterless ctor required for FieldListProperty
		public FieldList()
		{
		}

		internal FieldList(params int[] fieldNos)
		{
			this.AddRange(fieldNos);
		}

		public override string ToString()
		{
			return string.Join(",", this.Select(f => string.Format("Field{0}", f)));
		}
	}
}

