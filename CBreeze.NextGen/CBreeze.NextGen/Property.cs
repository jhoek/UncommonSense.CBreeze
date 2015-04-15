using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Property : INode
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

		public abstract IEnumerable<INode> ChildNodes
		{
			get;
		}
	}
}

