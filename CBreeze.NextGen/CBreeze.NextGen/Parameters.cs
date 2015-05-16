using System;

namespace CBreeze.NextGen
{
	public class Parameters:  KeyedContainer<string, Parameter>
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

