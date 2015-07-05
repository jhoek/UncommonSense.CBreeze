namespace CBreeze.NextGen
{
	public class ByteParameter : Parameter
	{
		public ByteParameter(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "ByteParameter";
        }
        
		public override ParameterType Type
		{
			get
			{
				return ParameterType.Byte;
			}
		}
	}
}
