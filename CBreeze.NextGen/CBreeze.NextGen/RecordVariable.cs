using System;

namespace CBreeze.NextGen
{
	public class RecordVariable : Variable
	{
		private int subType;

		public override string ToString()
		{
			return string.Format("{0}@{1} : Record {2}", Name, UID, SubType);
		}

		public RecordVariable(int uid, string name, int subType) :
			base(uid, name)
		{
			this.subType = subType;
		}

		public int SubType
		{
			get
			{
				return this.subType;
			}
		}
	}
}

