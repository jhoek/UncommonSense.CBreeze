namespace CBreeze.NextGen
{
	public class BigTextVariable : Variable
	{
		public BigTextVariable(int uid, string name)
		     : base(uid, name)
		{
		}

        public override string ToString()
        {
            return "BigTextVariable";
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
