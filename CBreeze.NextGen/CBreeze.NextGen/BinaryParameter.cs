using System;

namespace CBreeze.NextGen
{
	public class BinaryParameter : Parameter
	{
		public BinaryParameter(int uid, string name, int dataLength)
			: base(uid, name)
		{
		}

		public int DataLength
		{
			get;
			internal set;
		}

		public override ParameterType Type
		{
			get
			{
				return ParameterType.Binary;
			}
		}
	}
}

