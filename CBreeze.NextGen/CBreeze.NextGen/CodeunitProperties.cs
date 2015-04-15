using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class CodeunitProperties : Properties
	{
		private ValueProperty<int?> tableNo = new ValueProperty<int?>("TableNo");

		internal CodeunitProperties(Node parentNode)
			: base(parentNode)
		{
		}

		public override string ToString()
		{
			return "Properties";
		}

		public int? TableNo
		{
			get
			{
				return this.tableNo.Value;
			}set
			{
				this.tableNo.Value = value;
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return this.tableNo;
			}
		}
	}
}

