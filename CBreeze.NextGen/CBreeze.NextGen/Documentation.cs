using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Documentation :Node
	{
		public Documentation()
		{
			Lines = new List<string>();
		}

		public List<string> Lines
		{
			get;
			internal set;
		}
	}
}

