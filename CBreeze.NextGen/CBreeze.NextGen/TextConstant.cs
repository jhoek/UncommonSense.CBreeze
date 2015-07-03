using System;

namespace CBreeze.NextGen
{
	public class TextConstant : Variable
	{
		public TextConstant(int uid, string name)
			: base(uid, name)
		{
			Values = new MultiLanguageValue();
		}

		public override string ToString()
		{
			return string.Format("{0} {1}@{2}: {3}", Type, Name, UID, Values);
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.TextConstant;
			}
		}

		public MultiLanguageValue Values
		{
			get;
			internal set;
		}
	}
}

