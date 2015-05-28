using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
	public class Enumeration : ObjectModelElement
	{
		public Enumeration(string name, params string[] values)
			: base(name)
		{
			Values = new List<string>();
            Values.AddRange(values);
		}

		public List<string> Values
		{
			get;
			internal set;
		}
	}
}
