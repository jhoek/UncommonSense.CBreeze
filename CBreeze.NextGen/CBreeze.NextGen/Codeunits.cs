using System;

namespace CBreeze.NextGen
{
	public class Codeunits : Container<int, Codeunit>
	{
		internal Codeunits(Node parentNode, params Codeunit[] codeunits)
			: base(parentNode, codeunits)
		{
		}

		public override string ToString()
		{
			return "Codeunits";
		}
	}
}

