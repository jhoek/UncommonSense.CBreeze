using System;

namespace CBreeze.NextGen
{
	public class ActionVariable : Variable
	{
		public ActionVariable(int uid, string name)
			: base(uid, name)
		{
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.Action;
			}
		}
	}
}
