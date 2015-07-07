namespace CBreeze.NextGen
{
    public partial class ActionVariable : Variable
	{
		public ActionVariable(int uid, string name)
			: base(uid, name)
		{
		}

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", "ActionVariable", UID, Name);
        }
        
		public override VariableType Type
		{
			get
			{
				return VariableType.Action;
			}
		}
	}
}
