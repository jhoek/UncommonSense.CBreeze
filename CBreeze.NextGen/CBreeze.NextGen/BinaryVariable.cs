using System;

namespace CBreeze.NextGen
{
	public class BinaryVariable : Variable
	{
		public BinaryVariable(int uid, string name, int dataLength)
			: base(uid, name)
		{
			DataLength = dataLength;
		}

		public int DataLength
		{
			get;
			internal set;
		}

		public override VariableType Type
		{
			get
			{
				return VariableType.Binary;
			}
		}
	}
}

