namespace CBreeze.NextGen
{
	public class BigIntegerVariable : Variable
	{
		public BigIntegerVariable(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "BigIntegerVariable";
        }
        
		public override VariableType Type
		{
			get
			{
				return VariableType.BigInteger;
			}
		}
	}
}
