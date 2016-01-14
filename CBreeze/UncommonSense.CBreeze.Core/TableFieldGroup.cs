using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public partial class TableFieldGroup : KeyedItem<int>, IHasName
	{
		public TableFieldGroup(int id, string name)
		{
			ID = id;
			Name = name;
			Fields = new FieldList();
			Properties = new TableFieldGroupProperties();
		}

		public string Name
		{
			get;
			protected set;
		}

		public FieldList Fields
		{
			get;
			protected set;
		}

		public TableFieldGroupProperties Properties
		{
			get;
			protected set;
		}

		public string GetName()
		{
			return Name;
		}
	}
}
