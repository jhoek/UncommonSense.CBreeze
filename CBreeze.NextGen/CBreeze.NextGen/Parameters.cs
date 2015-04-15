using System;

namespace CBreeze.NextGen
{
	public class Parameters:  Container<string, Parameter>
	{
		internal Parameters(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Parameters";
		}
	}
}

