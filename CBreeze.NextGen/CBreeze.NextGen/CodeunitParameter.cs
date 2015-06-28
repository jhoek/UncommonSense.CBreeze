using System;

namespace CBreeze.NextGen
{
	public class CodeunitParameter : Parameter
	{
		public CodeunitParameter(int uid, string name, int subType)
			: base(uid, name)
		{
			SubType = subType;
		}

		public int SubType
		{
			get;
			internal set;
		}

		public override ParameterType Type
		{
			get
			{
				return ParameterType.Codeunit;
			}
		}
	}
}

