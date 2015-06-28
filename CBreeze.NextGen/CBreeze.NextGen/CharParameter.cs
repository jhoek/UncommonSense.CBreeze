using System;

namespace CBreeze.NextGen
{
	public class CharParameter : Parameter
	{
		public CharParameter(int uid, string name)
			: base(uid, name)
		{
		}

		public override ParameterType Type
		{
			get
			{
				return ParameterType.Char;
			}
		}
	}
}

