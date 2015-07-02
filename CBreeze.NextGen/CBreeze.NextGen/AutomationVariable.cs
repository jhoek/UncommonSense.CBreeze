namespace CBreeze.NextGen
{
	public class AutomationVariable : Variable
	{
		public AutomationVariable(int uid, string name, string subType)
			: base(uid, name)
		{
			SubType = subType;
		}

        public override string ToString()
        {
            return "AutomationVariable";
        }
        
		public override VariableType Type
		{
			get
			{
				return VariableType.Automation;
			}
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
	}
}
