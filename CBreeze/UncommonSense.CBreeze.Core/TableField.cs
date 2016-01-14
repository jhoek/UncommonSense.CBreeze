using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public abstract partial class TableField : KeyedItem<int>, IHasName, IHasProperties
	{
		internal TableField(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString()
		{
			return string.Format("{0}@{1}:{2}", Name, ID, Type);
		}

		public abstract TableFieldType Type
		{
			get;
		}

		public string Name
		{
			get;
			set;
		}

		public string QuotedName
		{
			get
			{
				return Name.Quoted();
			}
		}

		public bool? Enabled
		{
			get;
			set;
		}

		public string GetName()
		{
			return Name;
		}

		public abstract Properties AllProperties
		{
			get;
		}
	}
}
