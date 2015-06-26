using System;

namespace CBreeze.NextGen
{
	public class BigTextParameter : Parameter
	{
		public BigTextParameter(int uid, string name) : base(uid, name)
		{
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

