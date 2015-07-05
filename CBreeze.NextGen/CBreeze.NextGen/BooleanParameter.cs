namespace CBreeze.NextGen
{
	public class BooleanParameter : Parameter
	{
		public BooleanParameter(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "BooleanParameter";
        }
        
		public override ParameterType Type
		{
			get
			{
				return ParameterType.Boolean;
			}
		}
	}
}
