using System;

namespace CBreeze.NextGen
{
	public class XmlPorts : Container<int, XmlPort>
	{
		internal XmlPorts(Node parentNode) : base(parentNode)
		{
		}

		public override string ToString()
		{
			return "XmlPorts";
		}
	}
}

