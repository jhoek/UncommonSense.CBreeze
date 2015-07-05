namespace CBreeze.NextGen
{
	public class BooleanVariable : Variable
	{
		public BooleanVariable(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "BooleanVariable";
        }
        
		public override VariableType Type
		{
			get
			{
				return VariableType.Boolean;
			}
		}

		public bool? IncludeInDataset
		{
			get;
			set;
		}
	}
}
