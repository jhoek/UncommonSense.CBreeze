using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Documentation :Node
	{
		public Documentation(Node parentNode)
		{
			ParentNode = parentNode;
			Lines = new List<string>();
		}

		public override string ToString()
		{
			return "Documentation";
		}

		public List<string> Lines
		{
			get;
			internal set;
		}
	}
}

