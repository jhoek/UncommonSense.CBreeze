namespace CBreeze.NextGen
{
	public class CharVariable : Variable
	{
		public CharVariable(int uid, string name)
			: base(uid, name)
		{
		}

		public override string ToString()
		{
			return "CharVariable";
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.Char;
			}
		}
	}
}
