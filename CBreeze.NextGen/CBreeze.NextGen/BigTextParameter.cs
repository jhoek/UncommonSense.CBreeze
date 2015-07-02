namespace CBreeze.NextGen
{
	public class BigTextParameter : Parameter
	{
		public BigTextParameter(int uid, string name)
			: base(uid, name)
		{
		}

		public override string ToString()
		{
			return "BigTextParameter";
		}

		public override ParameterType Type
		{
			get
			{
				return ParameterType.BigText;
			}
		}
	}
}
