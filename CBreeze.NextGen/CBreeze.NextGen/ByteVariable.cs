namespace CBreeze.NextGen
{
	public class ByteVariable : Variable
	{
		public ByteVariable(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "ByteVariable";
        }
        
		public override VariableType Type
		{
			get
			{
				return VariableType.Byte;
			}
		}
	}
}
