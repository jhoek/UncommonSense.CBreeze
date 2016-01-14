using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
	[Serializable]
	public partial class ReportLabel : KeyedItem<int>, IHasName
	{
		public ReportLabel(int id, string name)
		{
			ID = id;
			Name = name;
			Properties = new ReportLabelProperties();
		}

		public string Name
		{
			get;
			protected set;
		}

		public ReportLabelProperties Properties
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
