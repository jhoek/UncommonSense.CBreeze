namespace CBreeze.NextGen
{
	public class ActionParameter : Parameter
	{
		public ActionParameter(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return "ActionParameter";
        }
        
		public override ParameterType Type
		{
			get
			{
				return ParameterType.Action;
			}
		}
	}
}