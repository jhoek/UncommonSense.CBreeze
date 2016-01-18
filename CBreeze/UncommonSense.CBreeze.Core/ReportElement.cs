using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public abstract class ReportElement : KeyedItem<int>, IHasName, IHasProperties
	{
		public ReportElement(int id, int? indentationLevel)
		{
			ID = id;
			IndentationLevel = indentationLevel;
		}

		public abstract ReportElementType Type
		{
			get;
		}

		public int? IndentationLevel
		{
			get;
			protected set;
		}

		public string Name
		{
			get;
			set;
		}

		public abstract Properties AllProperties
		{
			get;
		}

		public string GetName()
		{
			return Name;
		}
	}
}
