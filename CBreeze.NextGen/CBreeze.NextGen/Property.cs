using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Property : Node
	{
		internal Property(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
			internal set;
		}

		public abstract bool HasValue
		{
			get;
		}
	}
}

