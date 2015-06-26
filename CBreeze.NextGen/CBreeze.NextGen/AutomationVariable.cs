using System;

namespace CBreeze.NextGen
{
	public class AutomationVariable : Variable
	{
		public AutomationVariable(int uid, string name, string subType) : base(uid, name)
		{
			SubType = subType;
		}

		public string SubType
		{
			get;
			internal set;
		}

		public bool? WithEvents
		{
			get;
			set;
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.Automation;
			}
		}
	}
}

