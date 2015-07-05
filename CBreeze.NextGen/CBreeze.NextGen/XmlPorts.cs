namespace CBreeze.NextGen
{
	public class XmlPorts : KeyedContainer<int,XmlPort>
	{
		internal XmlPorts(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "XmlPorts";
		}
	}
}
