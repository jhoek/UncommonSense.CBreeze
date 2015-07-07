namespace CBreeze.NextGen
{
    public partial class ActionParameter : Parameter
	{
		public ActionParameter(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", "ActionParameter", UID, Name);
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