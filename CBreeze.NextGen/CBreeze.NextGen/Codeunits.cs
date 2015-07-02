namespace CBreeze.NextGen
{
	public class Codeunits : KeyedContainer<int, Codeunit>
	{
		internal Codeunits(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Codeunits";
		}
	}
}
