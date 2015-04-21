using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
	public class Properties : IEnumerable<Property>
	{
		private List<Property> innerList = new List<Property>();

		internal Properties(Item item)
		{
			Item = item;
		}

		public Item Item
		{
			get;
			internal set;
		}

		public IEnumerator<Property> GetEnumerator()
		{
			return innerList.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return innerList.GetEnumerator();
		}
	}
}
