using System;

namespace CBreeze.NextGen
{
	public class ActionParameter : Parameter
	{
		public ActionParameter(int uid, string name)
			: base(uid, name)
		{
		}

		public override ParameterType Type
		{
			get
			{
				return ParameterType.Action;
			}
		}
	}
}

