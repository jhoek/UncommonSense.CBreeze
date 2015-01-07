using System;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.DomBuilder
{
	public class Enum : Node
	{
		private string name;
		private List<string> values = new List<string>();

		public Enum(string name, params string[] values)
		{
			this.name = name;
			this.values.AddRange(values);	
		}

		public override string Name
		{
			get
			{
				return this.name;
			}
		}

		public IEnumerable<string> Values
		{
			get
			{
				return this.values;
			}
		}
	}
}

