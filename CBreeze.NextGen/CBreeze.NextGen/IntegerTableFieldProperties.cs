using System;
using System.Collections.Generic;
using System.Linq;

namespace CBreeze.NextGen
{
	public class IntegerTableFieldProperties : Properties
	{
		private StringProperty altSearchField = new StringProperty("AltSearchField");

		internal IntegerTableFieldProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public string AltSearchField
		{
			get
			{
				return this.altSearchField.Value;
			}
			set
			{
				this.altSearchField.Value = value;
			}
		}

		public override string ToString()
		{
			return "Properties";
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return altSearchField;
			}
		}
	}
}

