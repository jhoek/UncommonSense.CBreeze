using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Property : INode
	{
		private string name;

		internal Property(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public abstract IEnumerable<INode> ChildNodes
		{
			get;
		}
	}
}

