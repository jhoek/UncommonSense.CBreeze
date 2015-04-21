using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
	public class Properties : IEnumerable<Property>
	{
		internal Properties(Item item)
		{
			Item = item;
		}

		public Item Item
		{
			get;
			internal set;
		}
	}
}
