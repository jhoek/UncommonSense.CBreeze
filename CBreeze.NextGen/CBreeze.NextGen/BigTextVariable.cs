using System;

namespace CBreeze.NextGen
{
	public class BigTextVariable : Variable
	{
		public BigTextVariable(int uid, string name) : base(uid, name)
		{
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.BigText;
			}
		}
	}
}

