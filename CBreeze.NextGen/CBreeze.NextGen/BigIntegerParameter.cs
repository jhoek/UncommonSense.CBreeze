namespace CBreeze.NextGen
{
	public class BigIntegerParameter : Parameter
	{
		public BigIntegerParameter(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "BigIntegerParameter";
        }
        
		public override ParameterType Type
		{
			get
			{
				return ParameterType.BigInteger;
			}
		}
	}
}
