using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
	public class MaxOccursProperty : ValueProperty<MaxOccurs?>
	{
		internal MaxOccursProperty(string name)
			: base(name, (v) => {
				return v.HasValue;
			})
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
