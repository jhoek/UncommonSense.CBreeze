using System;

namespace CBreeze.NextGen
{
	public class RecordVariable : Variable
	{
		public RecordVariable(int uid, string name, int subType) : base(uid, name)
		{
			SubType = subType;
		}

		public override string ToString()
		{
			return string.Format("{0}@{1} : Record {2}", Name, UID, SubType);
		}

		public int SubType
		{
			get;
			internal set;
		}
	}
}

