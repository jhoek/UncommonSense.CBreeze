namespace CBreeze.NextGen
{
	public class BinaryParameter : Parameter
	{
		public BinaryParameter(int uid, string name, int dataLength)
			: base(uid, name)
		{
            DataLength = dataLength;
		}

                public override string ToString()
                {
                  return "BinaryParameter";
                  }

		public override ParameterType Type
		{
			get
			{
				return ParameterType.Binary;
			}
		}
		
		public int DataLength
		{
			get;
			internal set;
		}
	}
}
