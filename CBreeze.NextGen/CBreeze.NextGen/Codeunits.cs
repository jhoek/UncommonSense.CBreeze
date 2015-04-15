using System;

namespace CBreeze.NextGen
{
	public class Codeunits : Container<int, Codeunit>
	{
		internal Codeunits(Node parentNode) : base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Codeunits";
		}
	}
}

